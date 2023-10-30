using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;
using Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Services;
using Sholo.HomeAssistant.Client.WebSockets.Messages.States;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
public interface IHomeAssistantWebSocketsClient
{
    IObservable<WebsocketsConnectionState> ConnectionStateChanges { get; }
    void WaitForConnection(CancellationToken cancellationToken = default);

    IAsyncEnumerable<IEventMessage> SubscribeAsync(string? eventType = null, Func<IEventMessage, bool>? predicate = null, CancellationToken cancellationToken = default);
    IAsyncEnumerable<IEventMessage<TPayload>> SubscribeAsync<TPayload>(string? eventType = null, Func<IEventMessage<TPayload>, bool>? predicate = null, CancellationToken cancellationToken = default);

    Task CallServiceAsync(string domain, string service, IDictionary<string, object>? serviceData = null, CancellationToken cancellationToken = default);

    Task<StatesResult> GetStatesAsync(CancellationToken cancellationToken = default);
    Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default);
    Task<IDictionary<string, IDictionary<string, ServiceDefinition>>> GetServicesAsync(CancellationToken cancellationToken = default);
    Task<IDictionary<string, ComponentRegistration>> GetPanelsAsync(CancellationToken cancellationToken = default);
    Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default);
    Task<MediaPlayerThumbnailResult> GetMediaPlayerThumbnailAsync(string entityId, CancellationToken cancellationToken = default);
    Task PingAsync(CancellationToken cancellationToken = default);
}
