namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class SwitchDomain : BaseDomain
{
    public override string Name { get; } = "switch";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/switch/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/switch.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/switch/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/switch/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/switch/strings.json";
}
