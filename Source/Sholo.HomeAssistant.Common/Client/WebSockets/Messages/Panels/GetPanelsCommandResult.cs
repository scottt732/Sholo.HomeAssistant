using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;

public class GetPanelsCommandResult : BaseCommandResult<IDictionary<string, ComponentRegistration>>
{
    public GetPanelsCommandResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
