using System.Net;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.Rest.Models;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Client.Shared.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Events;
using Sholo.HomeAssistant.Exceptions;
using Sholo.HomeAssistant.Serialization;
using Sholo.HomeAssistant.StateDeserializers;

// ReSharper disable once UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Sholo.HomeAssistant.Client.Rest;

[PublicAPI]
public class HomeAssistantRestClient : IHomeAssistantRestClient
{
    private HttpClient HttpClient { get; }
    private MediaTypeFormatter[] MediaTypeFormatters { get; }
    private JsonSerializer JsonSerializer { get; }
    private IStateProvider StateProvider { get; }
    private IStateCodeGenerator StateCodeGenerator { get; }

    public HomeAssistantRestClient(
        HttpClient httpClient,
        IStateProvider stateProvider,
        IStateCodeGenerator stateCodeGenerator)
    {
        HttpClient = httpClient;
        StateProvider = stateProvider;
        StateCodeGenerator = stateCodeGenerator;

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
        CancellationTokenSource? cts = null;
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
    public Task<EventResult[]> GetEventsAsync(CancellationToken cancellationToken = default) => GetAsync<EventResult[]>(RestClientUris.Events, cancellationToken);

    // TODO: structure is different than websockets version
    public Task<JToken> GetServicesAsync(CancellationToken cancellationToken = default) => GetAsync<JToken>(RestClientUris.Services, cancellationToken);

    public Task<IEntityState[][]> GetHistoryAsync(string[]? entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
        => GetHistoryAsync<IEntityState>(entityIds, startTime, endTime, cancellationToken);

    public Task<TEntityState[][]> GetHistoryAsync<TEntityState>(string[]? entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
        where TEntityState : IEntityState
        => GetAsync<TEntityState[][]>(RestClientUris.History(entityIds, startTime, endTime), cancellationToken);

    public Task<IEntityState> GetStateAsync(string entityId, CancellationToken cancellationToken = default)
        => GetStateAsync<IEntityState>(entityId, cancellationToken);

    public Task<TEntityState> GetStateAsync<TEntityState>(string entityId, CancellationToken cancellationToken = default)
        where TEntityState : IEntityState
        => GetAsync<TEntityState>(RestClientUris.StatesForEntity(entityId), cancellationToken);

    public async IAsyncEnumerable<IEntityState> GetStatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync(
            RestClientUris.States,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken);

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        await foreach (var entityState in GetEntityStatePayloadsEnumerableAsync(response, cancellationToken))
        {
            yield return entityState;
        }
    }

    public async Task<string[]> GetErrorLogAsync(CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync(
            RestClientUris.ErrorLog,
            cancellationToken);

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        using var reader = new StreamReader(stream);
        var lines = new List<string>();
        while (await reader.ReadLineAsync(cancellationToken) is { } line)
        {
            lines.Add(line);
        }

        return lines.ToArray();
    }

    public async Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync(
            RestClientUris.CameraThumbnail(entityId),
            cancellationToken);

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        var content = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        var contentType = response.Content.Headers.ContentType?.MediaType;

        return new CameraThumbnailResult(content, contentType);
    }

    public async Task<CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes>> CreateOrUpdateStateAsync<TState, TStateValue, TStateAttributes>(
        TState state,
        CancellationToken cancellationToken = default
    )
        where TState : IEntityState<TStateValue, TStateAttributes>
    {
        ArgumentNullException.ThrowIfNull(state);
        ArgumentException.ThrowIfNullOrEmpty(state.EntityId);

        var response = await HttpClient.PostAsync(
            RestClientUris.StatesForEntity(state.EntityId),
            state,
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        var stateAction = response.StatusCode == HttpStatusCode.Created
            ? CreateOrUpdateStateResultType.Created
            : CreateOrUpdateStateResultType.Updated;

        var newState = await response.Content.ReadAsAsync<TState>(cancellationToken);
        var entityUri = response.Headers.Location;

        return new CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes>(
            stateAction,
            newState,
            entityUri
        );
    }

    public async Task<CreateOrUpdateStateResult<TState, TStateAttributes>> CreateOrUpdateStateAsync<TState, TStateAttributes>(
        TState state,
        CancellationToken cancellationToken = default
    )
        where TState : IEntityState<TStateAttributes>
    {
        ArgumentNullException.ThrowIfNull(state);
        ArgumentException.ThrowIfNullOrEmpty(state.EntityId);

        var response = await HttpClient.PostAsync(
            RestClientUris.StatesForEntity(state.EntityId),
            state,
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        var stateAction = response.StatusCode == HttpStatusCode.Created
            ? CreateOrUpdateStateResultType.Created
            : CreateOrUpdateStateResultType.Updated;

        var newState = await response.Content.ReadAsAsync<TState>(cancellationToken);
        var entityUri = response.Headers.Location;

        return new CreateOrUpdateStateResult<TState, TStateAttributes>(
            stateAction,
            newState,
            entityUri
        );
    }

    public async Task<MessageResult> FireEventAsync(string eventType, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.EventsOfType(eventType),
            null,
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        return await response.Content.ReadAsAsync<MessageResult>(cancellationToken);
    }

    public async Task<MessageResult> FireEventAsync(string eventType, IDictionary<string, object> eventData, CancellationToken cancellationToken = default)
    {
        // TODO: Check overload w/dictionary

        var response = await HttpClient.PostAsync(
            RestClientUris.EventsOfType(eventType),
            eventData,
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        return await response.Content.ReadAsAsync<MessageResult>(cancellationToken);
    }

    public async Task<MessageResult> FireEventAsync<TEventData>(string eventType, TEventData eventData, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.EventsOfType(eventType),
            eventData,
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        return await response.Content.ReadAsAsync<MessageResult>(cancellationToken);
    }

    public async IAsyncEnumerable<IEntityState> InvokeServiceAsync(string domain, string service, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.Service(domain, service),
            null,
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        await foreach (var entityState in GetEntityStatePayloadsEnumerableAsync(response, cancellationToken))
        {
            yield return entityState;
        }
    }

    public async IAsyncEnumerable<IEntityState> InvokeServiceAsync(string domain, string service, IDictionary<string, object>? serviceData = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.Service(domain, service),
            serviceData,
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        await foreach (var entityState in GetEntityStatePayloadsEnumerableAsync(response, cancellationToken))
        {
            yield return entityState;
        }
    }

    public async IAsyncEnumerable<IEntityState> InvokeServiceAsync<TServiceData>(string domain, string service, TServiceData serviceData, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.Service(domain, service),
            serviceData,
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        await foreach (var entityState in GetEntityStatePayloadsEnumerableAsync(response, cancellationToken))
        {
            yield return entityState;
        }
    }

    public async Task<string> RenderTemplateAsync(string template, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.Template,
            new TemplateRequest { Template = template },
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        var renderedTemplate = await response.Content.ReadAsStringAsync(cancellationToken);

        return renderedTemplate;
    }

    public async Task<TResult> RenderTemplateAsync<TResult>(string template, CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.Template,
            new TemplateRequest { Template = template },
            MediaTypeFormatters[0],
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var streamReader = new StreamReader(stream);
        await using var jsonStringReader = new JsonTextReader(streamReader);

        var result = JsonSerializer.Deserialize<TResult>(jsonStringReader);

        return result!;
    }

    public async Task<CheckConfigResult> CheckConfigAsync(CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.PostAsync(
            RestClientUris.CheckConfig,
            null,
            cancellationToken
        );

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        return await response.Content.ReadAsAsync<CheckConfigResult>(cancellationToken);
    }

    private async Task<TResult> GetAsync<TResult>(Uri path, CancellationToken cancellationToken)
    {
        var response = await HttpClient.GetAsync(path, cancellationToken);

        await EnsureSuccessfulOrThrowAsync(response, cancellationToken);

        return await response.Content.ReadAsAsync<TResult>(MediaTypeFormatters, cancellationToken);
    }

    private async IAsyncEnumerable<EntityState> GetEntityStatePayloadsEnumerableAsync(HttpResponseMessage response, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);

        using var streamReader = new StreamReader(responseStream);
        await using var reader = new JsonTextReader(streamReader);

        while (await reader.ReadAsync(cancellationToken))
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var entityState = await LoadEntityStatePayloadAsync(reader, cancellationToken);
                yield return entityState;
            }
        }
    }

    private async Task<EntityState> LoadEntityStatePayloadAsync(JsonTextReader reader, CancellationToken cancellationToken)
    {
        var jObject = await JObject.LoadAsync(reader, cancellationToken);
        var entityId = jObject["entity_id"]?.Value<string>() ?? throw new InvalidOperationException();
        var state = jObject["state"]?.ToString();
        var attributes = jObject["attributes"]?.ToObject<Dictionary<string, object>>() ?? throw new InvalidOperationException();

        StateCodeGenerator.Observe(entityId, state!, attributes);

        var entityStateType = StateProvider.GetEntityStateType(entityId, attributes);
        var entityState = (EntityState?)jObject.ToObject(entityStateType, JsonSerializer);

        if (entityState != null && attributes.Count > 0)
        {
            foreach (var (k, v) in attributes)
            {
                entityState.RawAttributes[k] = v;
            }
        }

        return entityState!;
    }

    private async Task EnsureSuccessfulOrThrowAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            try
            {
                var error = await response.Content.ReadAsAsync<MessageResult>(MediaTypeFormatters, cancellationToken);
                throw new HomeAssistantApiException(error.Message);
            }
            catch
            {
                var errorMessageRaw = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HomeAssistantApiException(errorMessageRaw);
            }
        }
    }
}
