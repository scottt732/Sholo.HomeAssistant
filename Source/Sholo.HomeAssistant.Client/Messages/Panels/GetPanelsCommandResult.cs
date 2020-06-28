using System.Collections.Generic;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.Panels
{
    public class GetPanelsCommandResult : BaseCommandResult<IDictionary<string, ComponentRegistration>>
    {
        public GetPanelsCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
