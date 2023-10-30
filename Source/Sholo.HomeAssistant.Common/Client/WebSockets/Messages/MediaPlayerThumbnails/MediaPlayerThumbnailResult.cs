namespace Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;

public class MediaPlayerThumbnailResult
{
    public byte[] Content { get; }
    public string ContentType { get; }

    public MediaPlayerThumbnailResult(byte[] content, string contentType)
    {
        Content = content;
        ContentType = contentType;
    }
}
