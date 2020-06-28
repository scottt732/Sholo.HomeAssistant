using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.MediaPlayerThumbnails
{
    [PublicAPI]
    public class GetMediaPlayerThumbnailCommand : BaseCommand
    {
        private string EntityId { get; }

        public GetMediaPlayerThumbnailCommand(string entityId)
        {
            MessageType = HomeAssistantWsMessageType.MediaPlayerThumbnail;
            EntityId = entityId;
        }
    }
}
