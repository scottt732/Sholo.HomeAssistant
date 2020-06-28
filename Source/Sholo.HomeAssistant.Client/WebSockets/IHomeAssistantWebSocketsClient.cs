using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.Messages.Config;
using Sholo.HomeAssistant.Client.Messages.MediaPlayerThumbnails;
using Sholo.HomeAssistant.Client.Messages.Panels;
using Sholo.HomeAssistant.Client.Messages.Services;
using Sholo.HomeAssistant.Client.Messages.States;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;

namespace Sholo.HomeAssistant.Client.WebSockets
{
    [PublicAPI]
    public interface IHomeAssistantWebSocketsClient
    {
        IObservable<WebsocketsConnectionState> ConnectionStateChanges { get; }
        void WaitForConnection(CancellationToken cancellationToken = default);

        IAsyncEnumerable<EventMessage> Subscribe(string eventType = null, Func<EventMessage, bool> predicate = null, CancellationToken cancellationToken = default);
        IAsyncEnumerable<EventMessage<TPayload>> Subscribe<TPayload>(string eventType = null, Func<EventMessage<TPayload>, bool> predicate = null, CancellationToken cancellationToken = default);

        Task CallServiceAsync(string domain, string service, IDictionary<string, object> serviceData = null, CancellationToken cancellationToken = default);

        Task<StatesResult> GetStatesAsync(CancellationToken cancellationToken = default);
        Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default);
        Task<IDictionary<string, IDictionary<string, ServiceDefinition>>> GetServicesAsync(CancellationToken cancellationToken = default);
        Task<IDictionary<string, ComponentRegistration>> GetPanelsAsync(CancellationToken cancellationToken = default);
        Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default);
        Task<MediaPlayerThumbnailResult> GetMediaPlayerThumbnailAsync(string entityId, CancellationToken cancellationToken = default);
        Task PingAsync(CancellationToken cancellationToken = default);
    }
}
