using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Subscriptions
{
    public class UnsubscribeResult : BaseCommandResult
    {
        public UnsubscribeResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
