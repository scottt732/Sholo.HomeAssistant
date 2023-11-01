namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class TextDomain : BaseDomain
{
    public override string Name { get; } = "text";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/text/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/text.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/text/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/text/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/text/strings.json";
}
