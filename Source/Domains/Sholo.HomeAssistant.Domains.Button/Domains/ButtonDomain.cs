namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class ButtonDomain : BaseDomain
{
    public override string Name { get; } = "button";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/button/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/button.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/button/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/button/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/button/strings.json";
}
