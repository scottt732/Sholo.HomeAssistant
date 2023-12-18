namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

[PublicAPI]
public class TemplateResult
{
    public string Result { get; init; } = null!;
    public string[]? Listeners { get; init; }
}
