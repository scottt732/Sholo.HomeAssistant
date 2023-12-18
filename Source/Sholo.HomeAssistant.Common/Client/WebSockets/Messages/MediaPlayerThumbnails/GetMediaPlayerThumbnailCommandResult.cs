namespace Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;

public class GetMediaPlayerThumbnailCommandResult : BaseCommandResult<MediaPlayerThumbnail>
{
    public GetMediaPlayerThumbnailCommandResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
