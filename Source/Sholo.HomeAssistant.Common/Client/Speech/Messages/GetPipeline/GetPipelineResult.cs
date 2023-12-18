using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.GetPipeline;

[PublicAPI]
public class GetPipelineResult : BaseResultMessage
{
    public bool Success { get; set; }
    public PipelineResultItem Result { get; set; } = null!;

    public GetPipelineResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
