namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class VacuumDomain : BaseDomain
{
    public override string Name { get; } = "vacuum";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/vacuum/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/vacuum.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/vacuum/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/vacuum/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/vacuum/strings.json";
}
