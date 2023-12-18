using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.GetPipeline;

[PublicAPI]
public class GetPipelineMessage : BaseCommand
{
    public GetPipelineMessage()
    {
        MessageType = HomeAssistantWsMessageTypes.Instance.AssistPipelineGet();
    }
}
