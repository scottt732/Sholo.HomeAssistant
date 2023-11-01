namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class FanDomain : BaseDomain
{
    public override string Name { get; } = "fan";
    public override Uri? DocumentationUri { get; } = new Uri("https://www.home-assistant.io/integrations/fan/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new Uri("https://www.home-assistant.io/integrations/fan.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/fan/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/fan/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/fan/strings.json";
}
