using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;
#pragma warning disable CA1056
#pragma warning disable CA2227
[PublicAPI]
public class ComponentPanelCustomConfiguration
{
    public string Name { get; set; } = null!;
    public string SidebarTitle { get; set; } = null!;
    public string SidebarIcon { get; set; } = null!;
    public string UrlPath { get; set; } = null!;
    public IDictionary<string, object> Config { get; set; } = null!;
    public string WebcomponentPath { get; set; } = null!;
    public string JsUrl { get; set; } = null!;
    public string ModuleUrl { get; set; } = null!;
    public string UrlExclusiveGroup { get; set; } = null!;
    public bool? EmbedIframe { get; set; } = null!;
    public bool? TrustExternalScript { get; set; } = null!;
    public bool? RequireAdmin { get; set; } = null!;
}
#pragma warning restore CA2227
#pragma warning restore CA1056
