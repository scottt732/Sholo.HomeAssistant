namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class HumidifierDomain : BaseDomain
{
    public override string Name { get; } = "humidifier";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/humidifier/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/humidifier.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/humidifier/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/humidifier/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/humidifier/strings.json";
}
