using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.States
{
    public class GetStatesCommandResult : BaseCommandResult<JToken[]>
    {
        public GetStatesCommandResult()
            : base(HomeAssistantWsMessageType.Result)
        {
        }
    }
}
