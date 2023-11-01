namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class TagScannerDomain : BaseDomain
{
    public override string Name { get; } = "tag";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/tag/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/tag.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/tag/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/tag/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/tag/strings.json";
}
