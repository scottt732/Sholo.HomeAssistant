using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.CameraThumbnails
{
    public class GetCameraThumbnailCommandResult : BaseCommandResult<CameraThumbnail>
    {
        public GetCameraThumbnailCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
