namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class AlarmControlPanelDomain : BaseDomain
{
    public override string Name { get; } = "alarm_control_panel";
    public override string ManifestJsonPath { get; } = "homeassistant/components/alarm_control_panel/manifest.json";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/alarm_control_panel/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/alarm_control_panel.mqtt/", UriKind.Absolute);
}
