using System.Net.WebSockets;

namespace Sholo.HomeAssistant.Client.WebSockets.Callbacks;

[PublicAPI]
public interface IMessageCallback
{
    long Id { get; }
    HomeAssistantWsMessageType CommandType { get; }

    Task InvokeAsync(WebSocket webSocket, CancellationToken cancellationToken);
    Task HandleResultAsync(Stream responseStream, CancellationToken cancellationToken);
}
