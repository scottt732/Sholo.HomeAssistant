using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Services
{
    public class GetServicesCommand : BaseCommand
    {
        public GetServicesCommand()
        {
            MessageType = HomeAssistantWsMessageType.GetServices;
        }
    }
}