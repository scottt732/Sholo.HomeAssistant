using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.GetPipelineDebug;

[PublicAPI]
public class GetPipelineDebugMessage : BaseCommand
{
    public string PipelineId { get; }
    public string PipelineRunId { get; }

    public GetPipelineDebugMessage(string pipelineId, string pipelineRunId)
    {
        PipelineId = pipelineId;
        PipelineRunId = pipelineRunId;
        MessageType = HomeAssistantWsMessageTypes.Instance.AssistPipelineDebugGet();
    }
}
