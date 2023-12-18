namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Heartbeats;

public sealed class PingCommand : BaseCommand
{
    public PingCommand()
    {
        MessageType = HomeAssistantWsMessageTypes.Ping;
    }
}
