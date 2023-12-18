namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Subscriptions;

public class UnsubscribeResult : BaseCommandResult
{
    public UnsubscribeResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
