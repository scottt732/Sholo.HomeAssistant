namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;
#pragma warning disable CA1056
[PublicAPI]
public class ComponentRegistration
{
    public string ComponentName { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string Title { get; set; } = null!;
    public ComponentConfiguration Config { get; set; } = null!;
    public string UrlPath { get; set; } = null!;
    public bool RequireAdmin { get; set; }
}
#pragma warning restore CA1056
