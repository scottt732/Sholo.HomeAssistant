using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.ListPipeline;

[PublicAPI]
public class ListPipelineResult : BaseResultMessage
{
    public bool Success { get; set; }
    public PipelinesResult Result { get; set; } = null!;

    public ListPipelineResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
