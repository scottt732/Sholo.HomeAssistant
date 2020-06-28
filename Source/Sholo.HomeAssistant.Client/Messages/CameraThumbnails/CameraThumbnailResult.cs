namespace Sholo.HomeAssistant.Client.Messages.CameraThumbnails
{
    public class CameraThumbnailResult
    {
        public byte[] Content { get; }
        public string ContentType { get; }

        public CameraThumbnailResult(byte[] content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }
    }
}