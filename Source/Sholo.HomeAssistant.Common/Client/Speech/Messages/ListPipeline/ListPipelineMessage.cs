using System.Collections.Generic;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.ListPipeline;

[PublicAPI]
public class ListPipelineMessage : BaseCommand
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, object>? Data { get; } = new();

    public ListPipelineMessage(bool debug)
    {
        MessageType = debug ? HomeAssistantWsMessageTypes.Instance.AssistPipelineDebugList() : HomeAssistantWsMessageTypes.Instance.AssistPipelineList();
    }
}
