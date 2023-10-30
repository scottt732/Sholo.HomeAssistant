using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Services;

public class GetServicesCommandResult : BaseCommandResult<IDictionary<string, IDictionary<string, ServiceDefinition>>>
{
    public GetServicesCommandResult()
        : base(HomeAssistantWsMessageType.Result)
    {
    }
}
