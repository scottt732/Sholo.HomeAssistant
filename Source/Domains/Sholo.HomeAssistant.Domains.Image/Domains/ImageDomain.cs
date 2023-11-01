namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class ImageDomain : BaseDomain
{
    public override string Name { get; } = "image";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/image/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/image.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/button/manifest.json";
    public override string? StringsJsonPath { get; } = "homeassistant/components/button/strings.json";
}
