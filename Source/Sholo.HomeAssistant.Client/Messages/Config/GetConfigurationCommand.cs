using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Config
{
    public class GetConfigurationCommand : BaseCommand
    {
        public GetConfigurationCommand()
        {
            MessageType = HomeAssistantWsMessageType.GetConfig;
        }
    }
}