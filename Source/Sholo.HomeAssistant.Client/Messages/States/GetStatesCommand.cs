using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.States
{
    public class GetStatesCommand : BaseCommand
    {
        public GetStatesCommand()
        {
            MessageType = HomeAssistantWsMessageType.GetStates;
        }
    }
}