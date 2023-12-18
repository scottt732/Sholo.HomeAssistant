namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Config;

public class GetConfigurationCommandResult : BaseCommandResult<ConfigurationResult>
{
    public GetConfigurationCommandResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
