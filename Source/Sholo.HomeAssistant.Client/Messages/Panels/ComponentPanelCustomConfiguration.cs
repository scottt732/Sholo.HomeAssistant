using System.Collections.Generic;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Panels
{
#pragma warning disable CA1056
#pragma warning disable CA2227
    [PublicAPI]
    public class ComponentPanelCustomConfiguration
    {
        public string Name { get; set; }
        public string SidebarTitle { get; set; }
        public string SidebarIcon { get; set; }
        public string UrlPath { get; set; }
        public IDictionary<string, object> Config { get; set; }
        public string WebcomponentPath { get; set; }
        public string JsUrl { get; set; }
        public string ModuleUrl { get; set; }
        public string UrlExclusiveGroup { get; set; }
        public bool? EmbedIframe { get; set; }
        public bool? TrustExternalScript { get; set; }
        public bool? RequireAdmin { get; set; }
    }
#pragma warning restore CA2227
#pragma warning restore CA1056
}
