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
using Sholo.HomeAssistant.Client.Messages.DiscoveryInfo;
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
        private JsonSerializerSettings JsonSerializerSettings { get; }
        private MediaTypeFormatter[] MediaTypeFormatters { get; }
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
            JsonSerializerSettings = HomeAssistantSerializerSettings.JsonSerializerSettings;
            Logger = logger;

            MediaTypeFormatters = new MediaTypeFormatter[]
            {
                new JsonMediaTypeFormatter
                {
                    SerializerSettings = JsonSerializerSettings
                }
            };
        }

        public Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default) => GetAsync<ConfigurationResult>("config", cancellationToken);
        public Task<DiscoveryInfoResult> GetDiscoveryInfoAsync(CancellationToken cancellationToken = default) => GetAsync<DiscoveryInfoResult>("discovery_info", cancellationToken);
        public Task<EventResult[]> GetEventsAsync(CancellationToken cancellationToken = default) => GetAsync<EventResult[]>("events", cancellationToken);

        // TODO: structure is different than websockets version
        public Task<JToken> GetServicesAsync(CancellationToken cancellationToken = default) => GetAsync<JToken>("services", cancellationToken);

        public Task<EntityState[][]> GetHistoryAsync(string[] entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
            => GetHistoryAsync<EntityState>(entityIds, startTime, endTime, cancellationToken);

        public Task<TEntityState[][]> GetHistoryAsync<TEntityState>(string[] entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
            where TEntityState : EntityState
        {
            var filterSuffix = entityIds != null && entityIds.Length > 0
                ? "filter_entity_id=" + string.Join(",", entityIds)
                : null;

            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            if (startTime.HasValue && endTime.HasValue)
            {
                var effectiveFilterSuffix = filterSuffix != null ? $"&{filterSuffix}" : string.Empty;
                return GetAsync<TEntityState[][]>($"history/period/{startTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}?end_time={endTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", cancellationToken);
            }

            if (startTime.HasValue && !endTime.HasValue)
            {
                var effectiveFilterSuffix = filterSuffix != null ? $"?{filterSuffix}" : string.Empty;
                return GetAsync<TEntityState[][]>($"history/period/{startTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", cancellationToken);
            }

            if (!startTime.HasValue && endTime.HasValue)
            {
                var effectiveFilterSuffix = filterSuffix != null ? $"&{filterSuffix}" : string.Empty;
                return GetAsync<TEntityState[][]>($"history/period/{DateTimeOffset.Now.AddDays(-1):yyyy-MM-dd\\Thh:mm:sszzz}?end_time={endTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", cancellationToken);
            }

            if (!startTime.HasValue && !endTime.HasValue)
            {
                var effectiveFilterSuffix = filterSuffix != null ? $"?{filterSuffix}" : string.Empty;
                return GetAsync<TEntityState[][]>($"history/period{effectiveFilterSuffix}", cancellationToken);
            }

            throw new InvalidOperationException("This is impossible");
        }

        public Task<EntityState> GetStateAsync(string entityId, CancellationToken cancellationToken = default)
            => GetStateAsync<EntityState>(entityId, cancellationToken);

        public Task<TEntityState> GetStateAsync<TEntityState>(string entityId, CancellationToken cancellationToken = default)
            where TEntityState : EntityState
                => GetAsync<TEntityState>($"states/{entityId}", cancellationToken);

        public async IAsyncEnumerable<EntityState> GetStatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync("states", HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            response.EnsureSuccessStatusCode();

            var jsonSerializer = JsonSerializer.Create(JsonSerializerSettings);

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            using (var streamReader = new StreamReader(responseStream))
            using (var reader = new JsonTextReader(streamReader))
            {
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
                        var entityState = (EntityState)jObject.ToObject(entityStateType, jsonSerializer);

                        yield return entityState;
                    }
                }
            }
        }

        public async Task<string[]> GetErrorLogAsync(CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync("error_log", cancellationToken);

            response.EnsureSuccessStatusCode();

#if NETSTANDARD2_0
            using var stream = await response.Content.ReadAsStreamAsync();
#else
            await using var stream = await response.Content.ReadAsStreamAsync();
#endif
            using var reader = new StreamReader(stream);

            string line;
            var lines = new List<string>();
            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }

            return lines.ToArray();
        }

        public async Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync($"/api/camera_proxy/camera.{entityId}", cancellationToken);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsByteArrayAsync();
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
                $"/api/states/{entityId}",
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
                $"/api/states/{entityId}",
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
                $"/api/events/{eventType}",
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
                $"/api/events/{eventType}",
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
                $"/api/events/{eventType}",
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

        // TODO: Remove me
        public Task<JToken> GetTestAsync(string path, CancellationToken cancellationToken = default) => GetAsync<JToken>(path, cancellationToken);

        private async Task<TResult> GetAsync<TResult>(string path, CancellationToken cancellationToken)
        {
            var response = await HttpClient.GetAsync(path, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TResult>(MediaTypeFormatters, cancellationToken);
        }
    }
}
