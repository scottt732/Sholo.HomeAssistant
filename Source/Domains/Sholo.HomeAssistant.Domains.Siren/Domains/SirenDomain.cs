namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class SirenDomain : BaseDomain
{
    public override string Name { get; } = "siren";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/siren/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/siren.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/siren/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/siren/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/siren/strings.json";
}
