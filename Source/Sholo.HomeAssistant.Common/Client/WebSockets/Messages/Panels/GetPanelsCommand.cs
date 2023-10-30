namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;

public class GetPanelsCommand : BaseCommand
{
    public GetPanelsCommand()
    {
        MessageType = HomeAssistantWsMessageType.GetPanels;
    }
}
