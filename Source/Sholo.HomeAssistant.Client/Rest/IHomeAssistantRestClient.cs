using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.Events.StateChanged;
using Sholo.HomeAssistant.Client.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.Messages.Config;
using Sholo.HomeAssistant.Client.Messages.DiscoveryInfo;
using Sholo.HomeAssistant.Client.Messages.Events;

namespace Sholo.HomeAssistant.Client.Rest
{
    [PublicAPI]
    public interface IHomeAssistantRestClient
    {
        Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default);
        Task<DiscoveryInfoResult> GetDiscoveryInfoAsync(CancellationToken cancellationToken = default);
        Task<EventResult[]> GetEventsAsync(CancellationToken cancellationToken = default);
        Task<JToken> GetServicesAsync(CancellationToken cancellationToken = default);
        Task<EntityState[][]> GetHistoryAsync(string[] entityIds, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default);

        Task<TEntityState[][]> GetHistoryAsync<TEntityState>(string[] entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, CancellationToken cancellationToken = default)
            where TEntityState : EntityState;

        Task<EntityState> GetStateAsync(string entityId, CancellationToken cancellationToken = default);

        Task<TEntityState> GetStateAsync<TEntityState>(string entityId, CancellationToken cancellationToken = default)
            where TEntityState : EntityState;

        IAsyncEnumerable<EntityState> GetStatesAsync(CancellationToken cancellationToken = default);

        Task<string[]> GetErrorLogAsync(CancellationToken cancellationToken = default);

        Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default);

        Task<CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes>> CreateOrUpdateState<TState, TStateValue, TStateAttributes>(string entityId, TStateValue stateValue, TStateAttributes stateAttributes, CancellationToken cancellationToken = default)
            where TState : EntityState<TStateValue, TStateAttributes>;

        Task<CreateOrUpdateStateResult<TState, TStateAttributes>> CreateOrUpdateState<TState, TStateAttributes>(string entityId, TStateAttributes stateAttributes, CancellationToken cancellationToken = default)
            where TState : EntityState<TStateAttributes>;

        Task<MessageResult> FireEvent(string eventType, CancellationToken cancellationToken = default);
        Task<MessageResult> FireEvent(string eventType, IDictionary<string, object> eventData, CancellationToken cancellationToken = default);
        Task<MessageResult> FireEvent<TEventData>(string eventType, TEventData eventData, CancellationToken cancellationToken = default);

        // TODO: this could potentially be IAsyncEnumerable<EntityState>
        Task CallServiceAsync(string domain, string service, IDictionary<string, object> serviceData = null, CancellationToken cancellationToken = default);

        // TODO:
        /*
        // POST /api/services/<domain>/<service> endpoint
        Task<TState> CreateOrUpdateState<TState, TStateValue, TStateAttributes>(string entityId, TStateValue value, TStateAttributes attributes, CancellationToken cancellationToken = default)
            where TState : EntityState<TStateValue, TStateAttributes>;

        // POST /api/services/<domain>/<service> endpoint
        Task<TState> CreateOrUpdateState<TState, TStateAttributes>(string entityId, TStateAttributes attributes, CancellationToken cancellationToken = default)
            where TState : EntityState<TStateAttributes>;

        // POST /api/services/<domain>/<service> endpoint
        IAsyncEnumerable<EntityState> InvokeService(string domain, string service, CancellationToken cancellationToken = default);
        IAsyncEnumerable<EntityState> InvokeService(string domain, string service, IDictionary<string, object> serviceData, CancellationToken cancellationToken = default);
        IAsyncEnumerable<EntityState> InvokeService<TServiceData>(string domain, string service, TServiceData serviceData, CancellationToken cancellationToken = default);

        // POST /api/template
        Task<string> RenderTemplate(string template, CancellationToken cancellationToken = default);

        // POST /api/config/core/check_config
        Task<CheckConfigResult> CheckConfig(CancellationToken cancellationToken = default);

        // POST /api/event_forwarding
        Task<MessageResult> SetupEventForwarding(string host, string apiPassword, int? port = null, CancellationToken cancellationToken = default);

        // DELETE /api/event_forwarding
        Task<MessageResult> CancelEventForwarding(string host, string apiPassword, int? port = null, CancellationToken cancellationToken = default);
        */
    }
}
