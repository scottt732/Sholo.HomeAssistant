namespace Sholo.HomeAssistant.Client.Rest;

[PublicAPI]
public class CheckConfigResult
{
    public string Errors { get; set; } = null!;
    public CheckConfigResultValue Result { get; set; }
}
