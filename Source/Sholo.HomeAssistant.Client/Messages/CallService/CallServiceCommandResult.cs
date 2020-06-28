using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.CallService
{
    public class CallServiceCommandResult : BaseCommandResult
    {
        public CallServiceCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
