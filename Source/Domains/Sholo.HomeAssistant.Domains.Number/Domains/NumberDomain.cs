namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class NumberDomain : BaseDomain
{
    public override string Name { get; } = "number";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/number/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/number.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/number/manifest.json";
    public override string? StringsJsonPath { get; } = "homeassistant/components/number/strings.json";
}
