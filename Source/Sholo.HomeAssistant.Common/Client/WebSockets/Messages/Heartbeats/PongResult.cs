namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Heartbeats;

public class PongResult : BaseCommandResult
{
    public PongResult()
        : base(HomeAssistantWsMessageTypes.Pong)
    {
    }
}
