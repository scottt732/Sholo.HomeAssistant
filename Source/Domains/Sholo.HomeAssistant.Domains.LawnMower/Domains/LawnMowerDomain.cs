namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class LawnMowerDomain : BaseDomain
{
    public override string Name { get; } = "lawn_mower";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/lawn_mower/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/lawn_mower.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/lawn_mower/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/lawn_mower/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/lawn_mower/strings.json";
}
