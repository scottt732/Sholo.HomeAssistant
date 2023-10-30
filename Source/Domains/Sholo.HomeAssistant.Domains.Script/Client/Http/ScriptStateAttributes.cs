namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class ScriptStateAttributes
{
    public string FriendlyName { get; set; } = null!;
    public string LastTriggered { get; set; } = null!;
    public bool CanCancel { get; set; }
}
