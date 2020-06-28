using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Subscriptions
{
    public class UnsubscribeCommand : BaseSubscriptionMessage
    {
        public long Subscription { get; }

        public UnsubscribeCommand(long subscription)
        {
            Subscription = subscription;
            MessageType = HomeAssistantWsMessageType.UnsubscribeEvents;
        }
    }
}