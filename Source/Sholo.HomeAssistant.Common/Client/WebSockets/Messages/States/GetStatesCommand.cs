namespace Sholo.HomeAssistant.Client.WebSockets.Messages.States;

public class GetStatesCommand : BaseCommand
{
    public GetStatesCommand()
    {
        MessageType = HomeAssistantWsMessageTypes.GetStates;
    }
}
