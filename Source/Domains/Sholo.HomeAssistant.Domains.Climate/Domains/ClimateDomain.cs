namespace Sholo.HomeAssistant.Domains;

public class ClimateDomain : BaseDomain
{
    public override string Name { get; } = "climate";
    public override Uri? DocumentationUri { get; } = new Uri("https://www.home-assistant.io/integrations/climate/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new Uri("https://www.home-assistant.io/integrations/climate.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/climate/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/climate/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/climate/strings.json";
}
