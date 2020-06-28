using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.CameraThumbnails
{
    public class GetCameraThumbnailCommand : BaseCommand
    {
        public string EntityId { get; }

        public GetCameraThumbnailCommand(string entityId)
        {
            MessageType = HomeAssistantWsMessageType.CameraThumbnail;
            EntityId = entityId;
        }
    }
}