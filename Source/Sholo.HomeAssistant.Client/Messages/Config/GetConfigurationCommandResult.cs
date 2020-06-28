using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Config
{
    public class GetConfigurationCommandResult : BaseCommandResult<ConfigurationResult>
    {
        public GetConfigurationCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
