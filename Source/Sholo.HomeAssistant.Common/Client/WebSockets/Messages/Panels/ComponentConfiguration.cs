using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;

[PublicAPI]
public class ComponentConfiguration
{
    public ConfigMode Mode { get; set; }

    [JsonProperty("_panel_custom")]
    public ComponentPanelCustomConfiguration PanelCustom { get; set; } = null!;
}
