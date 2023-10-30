namespace Sholo.HomeAssistant.Domains;

public sealed class BinarySensorDomain : BaseDomain
{
    public override string Name { get; } = "binary_sensor";
    public override string ManifestJsonPath { get; } = "homeassistant/components/binary_sensor/manifest.json";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/binary_sensor/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/binary_sensor.mqtt/", UriKind.Absolute);
    public override string? StringsJsonPath { get; } = "homeassistant/components/binary_sensor/strings.json";
}
