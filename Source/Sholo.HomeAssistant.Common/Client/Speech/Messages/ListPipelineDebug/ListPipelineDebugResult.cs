using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.ListPipelineDebug;

[PublicAPI]
public class ListPipelineDebugResult : BaseResultMessage
{
    public bool Success { get; set; }
    public JToken Result { get; set; } = null!;

    public ListPipelineDebugResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
