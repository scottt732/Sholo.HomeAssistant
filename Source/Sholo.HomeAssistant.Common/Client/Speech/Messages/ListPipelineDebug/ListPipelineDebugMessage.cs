using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.ListPipelineDebug;

[PublicAPI]
public class ListPipelineDebugMessage : BaseCommand
{
    public string PipelineId { get; }

    public ListPipelineDebugMessage(string pipelineId)
    {
        MessageType = HomeAssistantWsMessageTypes.Instance.AssistPipelineDebugList();
        PipelineId = pipelineId;
    }
}
