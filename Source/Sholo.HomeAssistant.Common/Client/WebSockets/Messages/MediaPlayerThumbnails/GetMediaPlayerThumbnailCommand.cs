namespace Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;

[PublicAPI]
public class GetMediaPlayerThumbnailCommand : BaseCommand
{
    public string EntityId { get; }

    public GetMediaPlayerThumbnailCommand(string entityId)
    {
        MessageType = HomeAssistantWsMessageTypes.MediaPlayerThumbnail;
        EntityId = entityId;
    }
}
