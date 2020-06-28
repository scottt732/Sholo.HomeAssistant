using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Internal.Callbacks
{
    [PublicAPI]
    public interface IMessageCallback
    {
        long Id { get; }
        HomeAssistantWsMessageType CommandType { get; }

        Task Invoke(WebSocket webSocket, CancellationToken cancellationToken);
        Task HandleResult(Stream responseStream, CancellationToken cancellationToken);
    }
}
