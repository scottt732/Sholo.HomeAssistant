using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Speech;

public static class HomeAssistantWsMessageTypesExtensions
{
    // Speech
    public static HomeAssistantWsMessageType AssistPipelineGet(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/pipeline/get");
    public static HomeAssistantWsMessageType AssistPipelineList(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/pipeline/list");
    public static HomeAssistantWsMessageType AssistPipelineDeviceCapture(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/device/capture");
    public static HomeAssistantWsMessageType AssistPipelineDebugGet(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/pipeline_debug/get");
    public static HomeAssistantWsMessageType AssistPipelineDebugList(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/pipeline_debug/list");
    public static HomeAssistantWsMessageType AssistPipelineRun(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/run");
    public static HomeAssistantWsMessageType AssistPipelineLanguageList(this HomeAssistantWsMessageTypes t) => t.Register("assist_pipeline/language/list");
}
