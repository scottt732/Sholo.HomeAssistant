namespace Sholo.HomeAssistant.Client.Speech.Messages;

[PublicAPI]
public class PipelinesResult
{
    public PipelineResultItem[] Pipelines { get; set; } = null!;
    public string PreferredPipeline { get; set; } = null!;
}
