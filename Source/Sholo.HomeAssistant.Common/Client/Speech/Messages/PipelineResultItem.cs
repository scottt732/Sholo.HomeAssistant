namespace Sholo.HomeAssistant.Client.Speech.Messages;

[PublicAPI]
public class PipelineResultItem
{
    public string ConversationEngine { get; set; } = null!;
    public string ConversationLanguage { get; set; } = null!;
    public string Language { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string SttEngine { get; set; } = null!;
    public string SttLanguage { get; set; } = null!;
    public string TtsEngine { get; set; } = null!;
    public string TtsLanguage { get; set; } = null!;
    public string TtsVoice { get; set; } = null!;
    public string WakeWordEntity { get; set; } = null!;
    public string WakeWordId { get; set; } = null!;
    public string Id { get; set; } = null!;
}
