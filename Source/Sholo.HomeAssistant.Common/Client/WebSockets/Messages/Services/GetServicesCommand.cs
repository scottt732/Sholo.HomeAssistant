namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Services;

public class GetServicesCommand : BaseCommand
{
    public GetServicesCommand()
    {
        MessageType = HomeAssistantWsMessageType.GetServices;
    }
}
