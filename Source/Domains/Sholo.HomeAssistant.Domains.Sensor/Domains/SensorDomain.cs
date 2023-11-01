namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class SensorDomain : BaseDomain
{
    public override string Name { get; } = "sensor";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/sensor/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/sensor.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/sensor/manifest.json";
    public override string? StringsJsonPath { get; } = "homeassistant/components/sensor/strings.json";
}
