using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Internal.Callbacks
{
    public abstract class BaseMessageCallback : IMessageCallback
    {
        public long Id { get; }
        public HomeAssistantWsMessageType CommandType { get; }

        public abstract Task Invoke(WebSocket webSocket, CancellationToken cancellationToken);
        public abstract Task HandleResult(Stream responseStream, CancellationToken cancellationToken);

        protected BaseMessageCallback(long id, HomeAssistantWsMessageType commandType)
        {
            Id = id;
            CommandType = commandType;
        }
    }
}