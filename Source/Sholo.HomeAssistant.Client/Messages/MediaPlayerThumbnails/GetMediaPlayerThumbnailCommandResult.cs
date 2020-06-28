using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.MediaPlayerThumbnails
{
    public class GetMediaPlayerThumbnailCommandResult : BaseCommandResult<MediaPlayerThumbnail>
    {
        public GetMediaPlayerThumbnailCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
