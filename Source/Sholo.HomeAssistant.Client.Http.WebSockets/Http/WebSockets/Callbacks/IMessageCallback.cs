using System.Net.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.Callbacks;

[PublicAPI]
public interface IMessageCallback
{
    long Id { get; }
    HomeAssistantWsMessageType CommandType { get; }

    Task InvokeAsync(WebSocket webSocket, CancellationToken cancellationToken);
    Task HandleResultAsync(Stream responseStream, CancellationToken cancellationToken);
}
