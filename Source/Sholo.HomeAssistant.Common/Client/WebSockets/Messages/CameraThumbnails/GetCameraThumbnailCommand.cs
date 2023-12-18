namespace Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;

public class GetCameraThumbnailCommand : BaseCommand
{
    public string EntityId { get; }

    public GetCameraThumbnailCommand(string entityId)
    {
        MessageType = HomeAssistantWsMessageTypes.CameraThumbnail;
        EntityId = entityId;
    }
}
