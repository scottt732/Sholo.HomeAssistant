using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.Rest.Models;
using Sholo.HomeAssistant.Client.Shared.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Events;

namespace Sholo.HomeAssistant.Client.Rest;

[PublicAPI]
public interface IHomeAssistantRestClient
{
    Task<bool> GetApiEnabledAsync(TimeSpan? requestTimeout = null, CancellationToken cancellationToken = default);

    Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default);

    Task<EventResult[]> GetEventsAsync(CancellationToken cancellationToken = default);

    Task<JToken> GetServicesAsync(CancellationToken cancellationToken = default);

    Task<IEntityState[][]> GetHistoryAsync(string[] entityIds, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default);

    Task<TEntityState[][]> GetHistoryAsync<TEntityState>(string[]? entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
        where TEntityState : IEntityState;

    Task<IEntityState> GetStateAsync(string entityId, CancellationToken cancellationToken = default);

    Task<TEntityState> GetStateAsync<TEntityState>(string entityId, CancellationToken cancellationToken = default)
        where TEntityState : IEntityState;

    IAsyncEnumerable<IEntityState> GetStatesAsync(CancellationToken cancellationToken = default);

    Task<string[]> GetErrorLogAsync(CancellationToken cancellationToken = default);

    Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default);

    Task<CreateOrUpdateStateResult<TState, TStateAttributes>> CreateOrUpdateStateAsync<TState, TStateAttributes>(TState state, CancellationToken cancellationToken = default)
        where TState : IEntityState<TStateAttributes>;

    Task<CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes>> CreateOrUpdateStateAsync<TState, TStateValue, TStateAttributes>(TState state, CancellationToken cancellationToken = default)
        where TState : IEntityState<TStateValue, TStateAttributes>;

    Task<MessageResult> FireEventAsync(string eventType, CancellationToken cancellationToken = default);
    Task<MessageResult> FireEventAsync(string eventType, IDictionary<string, object> eventData, CancellationToken cancellationToken = default);
    Task<MessageResult> FireEventAsync<TEventData>(string eventType, TEventData eventData, CancellationToken cancellationToken = default);

    IAsyncEnumerable<IEntityState> InvokeServiceAsync(string domain, string service, CancellationToken cancellationToken = default);
    IAsyncEnumerable<IEntityState> InvokeServiceAsync(string domain, string service, IDictionary<string, object> serviceData, CancellationToken cancellationToken = default);
    IAsyncEnumerable<IEntityState> InvokeServiceAsync<TServiceData>(string domain, string service, TServiceData serviceData, CancellationToken cancellationToken = default);

    Task<string> RenderTemplateAsync(string template, CancellationToken cancellationToken = default);
    Task<TResult> RenderTemplateAsync<TResult>(string template, CancellationToken cancellationToken = default);

    Task<CheckConfigResult> CheckConfigAsync(CancellationToken cancellationToken = default);
}
