namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class UpdateDomain : BaseDomain
{
    public override string Name { get; } = "update";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/update/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/update.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/update/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/update/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/update/strings.json";
}
