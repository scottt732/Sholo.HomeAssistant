namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class WaterHeaterDomain : BaseDomain
{
    public override string Name { get; } = "water_heater";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/water_heater/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/water_heater.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/water_heater/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/water_heater/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/water_heater/strings.json";
}
