using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Heartbeats
{
    public class PongResult : BaseCommandResult
    {
        public PongResult()
            : base(HomeAssistantWsMessageType.Pong)
        {
        }
    }
}
