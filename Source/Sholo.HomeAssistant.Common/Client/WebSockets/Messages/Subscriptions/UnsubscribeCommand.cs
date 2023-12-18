namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Subscriptions;

public class UnsubscribeCommand : BaseSubscriptionMessage
{
    public long Subscription { get; }

    public UnsubscribeCommand(long subscription)
    {
        Subscription = subscription;
        MessageType = HomeAssistantWsMessageTypes.UnsubscribeEvents;
    }
}
