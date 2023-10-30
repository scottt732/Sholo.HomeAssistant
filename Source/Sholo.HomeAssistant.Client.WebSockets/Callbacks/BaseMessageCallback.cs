using System.Net.WebSockets;

namespace Sholo.HomeAssistant.Client.WebSockets.Callbacks;

public abstract class BaseMessageCallback : IMessageCallback
{
    public long Id { get; }
    public HomeAssistantWsMessageType CommandType { get; }

    public abstract Task InvokeAsync(WebSocket webSocket, CancellationToken cancellationToken);
    public abstract Task HandleResultAsync(Stream responseStream, CancellationToken cancellationToken);

    protected BaseMessageCallback(long id, HomeAssistantWsMessageType commandType)
    {
        Id = id;
        CommandType = commandType;
    }
}
