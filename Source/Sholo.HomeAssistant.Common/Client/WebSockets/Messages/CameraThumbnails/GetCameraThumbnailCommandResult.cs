namespace Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;

public class GetCameraThumbnailCommandResult : BaseCommandResult<CameraThumbnail>
{
    public GetCameraThumbnailCommandResult()
        : base(HomeAssistantWsMessageType.Result)
    {
    }
}
