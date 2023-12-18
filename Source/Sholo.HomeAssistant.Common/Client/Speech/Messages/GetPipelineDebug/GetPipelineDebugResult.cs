using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.GetPipelineDebug;

[PublicAPI]
public class GetPipelineDebugResult : BaseResultMessage
{
    public bool Success { get; set; }
    public JToken Result { get; set; } = null!;

    public GetPipelineDebugResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
