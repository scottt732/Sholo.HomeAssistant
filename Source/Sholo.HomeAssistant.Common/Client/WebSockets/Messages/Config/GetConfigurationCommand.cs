namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Config;

public class GetConfigurationCommand : BaseCommand
{
    public GetConfigurationCommand()
    {
        MessageType = HomeAssistantWsMessageTypes.GetConfig;
    }
}
