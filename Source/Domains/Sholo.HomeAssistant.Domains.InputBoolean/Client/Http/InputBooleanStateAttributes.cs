namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class InputBooleanStateAttributes
{
    public bool Editable { get; set; }
    public string FriendlyName { get; set; } = null!;
    public string Icon { get; set; } = null!;
}
