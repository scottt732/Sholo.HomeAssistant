using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Panels
{
    public class GetPanelsCommand : BaseCommand
    {
        public GetPanelsCommand()
        {
            MessageType = HomeAssistantWsMessageType.GetPanels;
        }
    }
}