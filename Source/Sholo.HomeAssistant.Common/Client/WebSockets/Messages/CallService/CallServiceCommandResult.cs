namespace Sholo.HomeAssistant.Client.WebSockets.Messages.CallService;

public class CallServiceCommandResult : BaseCommandResult
{
    public CallServiceCommandResult()
        : base(HomeAssistantWsMessageType.Result)
    {
    }
}
