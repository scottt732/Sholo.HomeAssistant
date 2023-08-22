using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.Events.StateChanged;
using Sholo.HomeAssistant.Client.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.Messages.Config;
using Sholo.HomeAssistant.Client.Messages.Events;
using Sholo.HomeAssistant.Client.Settings;
using Sholo.HomeAssistant.Client.StateDeserializers;
using Sholo.HomeAssistant.Serialization;

// ReSharper disable once UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Sholo.HomeAssistant.Client.Rest
{
    public class HomeAssistantRestClient : IHomeAssistantRestClient
    {
        private HttpClient HttpClient { get; }
        private MediaTypeFormatter[] MediaTypeFormatters { get; }
        private JsonSerializer JsonSerializer { get; }
        private IOptions<HomeAssistantClientOptions> HomeAssistantOptions { get; }
        private IStateProvider StateProvider { get; }
        private IStateCodeGenerator StateCodeGenerator { get; }
        private ILogger Logger { get; }

        public HomeAssistantRestClient(
            HttpClient httpClient,
            IOptions<HomeAssistantClientOptions> homeAssistantOptions,
            IStateProvider stateProvider,
            IStateCodeGenerator stateCodeGenerator,
            ILogger<HomeAssistantRestClient> logger)
        {
            HttpClient = httpClient;
            HomeAssistantOptions = homeAssistantOptions;
            StateProvider = stateProvider;
            StateCodeGenerator = stateCodeGenerator;
            Logger = logger;

            MediaTypeFormatters = new MediaTypeFormatter[]
            {
                new JsonMediaTypeFormatter
                {
                    SerializerSettings = HomeAssistantSerializerSettings.JsonSerializerSettings
                }
            };

            JsonSerializer = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);
        }

        public async Task<bool> GetApiEnabledAsync(TimeSpan? requestTimeout = null, CancellationToken cancellationToken = default)
        {
            CancellationTokenSource cts = null;
            try
            {
                CancellationToken token;
                if (requestTimeout.HasValue && requestTimeout.Value != HttpClient.Timeout)
                {
                    cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    cts.CancelAfter(requestTimeout.Value);
                    token = cts.Token;
                }
                else
                {
                    token = cancellationToken;
                }

                var response = await HttpClient.GetAsync(RestClientUris.IsEnabled, token);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var result = await response.Content.ReadAsAsync<TestResult>(MediaTypeFormatters, cancellationToken);

                if (result == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(result.Message))
                {
                    return false;
                }

                return true;
            }
            catch (TaskCanceledException)
            {
                return false;
            }
            catch (HttpRequestException)
            {
                return false;
            }
            finally
            {
                cts?.Dispose();
            }
        }

        public Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default) => GetAsync<ConfigurationResult>(RestClientUris.Config, cancellationToken);
        public Task<EventResult[]> GetEventsAsync(CancellationToken cancellationToken = default) => GetAsync<EventResult[]>(RestClientUris.Events(), cancellationToken);

        // TODO: structure is different than websockets version
        public Task<JToken> GetServicesAsync(CancellationToken cancellationToken = default) => GetAsync<JToken>(RestClientUris.Services, cancellationToken);

        public Task<EntityState[][]> GetHistoryAsync(string[] entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
            => GetHistoryAsync<EntityState>(entityIds, startTime, endTime, cancellationToken);

        public Task<TEntityState[][]> GetHistoryAsync<TEntityState>(string[] entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
            where TEntityState : EntityState
            => GetAsync<TEntityState[][]>(RestClientUris.History(entityIds, startTime, endTime), cancellationToken);

        public Task<EntityState> GetStateAsync(string entityId, CancellationToken cancellationToken = default)
            => GetStateAsync<EntityState>(entityId, cancellationToken);

        public Task<TEntityState> GetStateAsync<TEntityState>(string entityId, CancellationToken cancellationToken = default)
            where TEntityState : EntityState
                => GetAsync<TEntityState>(RestClientUris.StatesForEntity(entityId), cancellationToken);

        public async IAsyncEnumerable<EntityState> GetStatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync(
                RestClientUris.States,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken);

            response.EnsureSuccessStatusCode();

#if NETSTANDARD2_1
            await using var responseStream = await response.Content.ReadAsStreamAsync();
#elif NET5_0_OR_GREATER
            await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
#endif
            using var streamReader = new StreamReader(responseStream);
            using var reader = new JsonTextReader(streamReader);

            while (await reader.ReadAsync(cancellationToken))
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    var jObject = await JObject.LoadAsync(reader, cancellationToken);
                    var entityId = jObject["entity_id"]?.Value<string>() ?? throw new InvalidOperationException();
                    var state = jObject["state"]?.ToString();
                    var attributes = jObject["attributes"]?.ToObject<Dictionary<string, object>>() ?? throw new InvalidOperationException();

                    StateCodeGenerator.Observe(entityId, state, attributes);

                    var entityStateType = StateProvider.GetEntityStateType(entityId, attributes);
                    var entityState = (EntityState)jObject.ToObject(entityStateType, JsonSerializer);

                    yield return entityState;
                }
            }
        }

        public async Task<string[]> GetErrorLogAsync(CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync(
                RestClientUris.ErrorLog,
                cancellationToken);

            response.EnsureSuccessStatusCode();

#if NETSTANDARD2_1
            using (var stream = await response.Content.ReadAsStreamAsync())
#elif NET5_0_OR_GREATER
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
#endif

            using (var reader = new StreamReader(stream))
            {
                string line;
                var lines = new List<string>();
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }

                return lines.ToArray();
            }
        }

        public async Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync(
                RestClientUris.CameraThumbnail(entityId),
                cancellationToken);

            response.EnsureSuccessStatusCode();

#if NETSTANDARD2_1
            var content = await response.Content.ReadAsByteArrayAsync();
#elif NET5_0_OR_GREATER
            var content = await response.Content.ReadAsByteArrayAsync(cancellationToken);
#endif

            var contentType = response.Content.Headers.ContentType.MediaType;

            return new CameraThumbnailResult(content, contentType);
        }

        public async Task<CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes>> CreateOrUpdateState<TState, TStateValue, TStateAttributes>(
            string entityId,
            TStateValue stateValue,
            TStateAttributes stateAttributes,
            CancellationToken cancellationToken = default
        )
            where TState : EntityState<TStateValue, TStateAttributes>
        {
            var entityState = new EntityState<TStateValue, TStateAttributes>
            {
                State = stateValue,
                Attributes = stateAttributes
            };

            var response = await HttpClient.PostAsync(
                RestClientUris.StatesForEntity(entityId),
                entityState,
                MediaTypeFormatters[0],
                cancellationToken
            );

            response.EnsureSuccessStatusCode();

            var stateAction = response.StatusCode == HttpStatusCode.Created
                ? CreateOrUpdateStateResultType.Created
                : CreateOrUpdateStateResultType.Updated;

            var state = await response.Content.ReadAsAsync<TState>(cancellationToken);
            var entityUri = response.Headers.Location;

            return new CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes>(
                stateAction,
                state,
                entityUri
            );
        }

        public async Task<CreateOrUpdateStateResult<TState, TStateAttributes>> CreateOrUpdateState<TState, TStateAttributes>(
            string entityId,
            TStateAttributes stateAttributes,
            CancellationToken cancellationToken = default)
                where TState : EntityState<TStateAttributes>
        {
            var entityState = new EntityState<TStateAttributes>
            {
                Attributes = stateAttributes
            };

            var response = await HttpClient.PostAsync(
                RestClientUris.StatesForEntity(entityId),
                entityState,
                MediaTypeFormatters[0],
                cancellationToken
            );

            response.EnsureSuccessStatusCode();

            var stateAction = response.StatusCode == HttpStatusCode.Created
                ? CreateOrUpdateStateResultType.Created
                : CreateOrUpdateStateResultType.Updated;

            var state = await response.Content.ReadAsAsync<TState>(cancellationToken);
            var entityUri = response.Headers.Location;

            return new CreateOrUpdateStateResult<TState, TStateAttributes>(
                stateAction,
                state,
                entityUri
            );
        }

        public async Task<MessageResult> FireEvent(string eventType, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.PostAsync(
                new Uri($"/api/events/{eventType}", UriKind.Relative),
                null,
                cancellationToken
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<MessageResult>(cancellationToken);
        }

        public async Task<MessageResult> FireEvent(string eventType, IDictionary<string, object> eventData, CancellationToken cancellationToken = default)
        {
            // TODO: Check overload w/dictionary

            var response = await HttpClient.PostAsync(
                new Uri($"/api/events/{eventType}", UriKind.Relative),
                eventData,
                MediaTypeFormatters[0],
                cancellationToken
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<MessageResult>(cancellationToken);
        }

        public async Task<MessageResult> FireEvent<TEventData>(string eventType, TEventData eventData, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.PostAsync(
                new Uri($"/api/events/{eventType}", UriKind.Relative),
                eventData,
                MediaTypeFormatters[0],
                cancellationToken
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<MessageResult>(cancellationToken);
        }

        public Task CallServiceAsync(string domain, string service, IDictionary<string, object> serviceData = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private async Task<TResult> GetAsync<TResult>(Uri path, CancellationToken cancellationToken)
        {
            var response = await HttpClient.GetAsync(path, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TResult>(MediaTypeFormatters, cancellationToken);
        }
    }
}
