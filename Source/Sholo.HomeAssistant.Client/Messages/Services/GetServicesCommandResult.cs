using System.Collections.Generic;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Services
{
    public class GetServicesCommandResult : BaseCommandResult<IDictionary<string, IDictionary<string, ServiceDefinition>>>
    {
        public GetServicesCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
