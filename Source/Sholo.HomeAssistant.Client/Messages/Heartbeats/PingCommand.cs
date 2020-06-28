using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Heartbeats
{
    public sealed class PingCommand : BaseCommand
    {
        public PingCommand()
        {
            MessageType = HomeAssistantWsMessageType.Ping;
        }
    }
}