namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Services;

public class GetServicesCommand : BaseCommand
{
    public GetServicesCommand()
    {
        MessageType = HomeAssistantWsMessageTypes.GetServices;
    }
}
