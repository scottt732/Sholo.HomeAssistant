namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Subscriptions;

public class SubscribeResult : BaseCommandResult
{
    public SubscribeResult()
        : base(HomeAssistantWsMessageType.Result)
    {
    }
}
