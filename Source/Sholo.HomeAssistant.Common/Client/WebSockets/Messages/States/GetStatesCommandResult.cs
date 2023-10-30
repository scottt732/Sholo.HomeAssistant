using Newtonsoft.Json.Linq;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.States;

public class GetStatesCommandResult : BaseCommandResult<JToken[]>
{
    public GetStatesCommandResult()
        : base(HomeAssistantWsMessageType.Result)
    {
    }
}
