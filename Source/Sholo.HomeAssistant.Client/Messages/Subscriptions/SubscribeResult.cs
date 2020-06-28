using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Subscriptions
{
    public class SubscribeResult : BaseCommandResult
    {
        public SubscribeResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
