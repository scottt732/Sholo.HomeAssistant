namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class LightDomain : BaseDomain
{
    public override string Name { get; } = "light";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/light/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/light.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/light/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/light/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/light/strings.json";
}
