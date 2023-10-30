namespace Sholo.HomeAssistant.Domains;

public class DeviceTrackerDomain : BaseDomain
{
    public override string Name { get; } = "device_tracker";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/device_tracker/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/device_tracker.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/device_tracker/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/device_tracker/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/device_tracker/strings.json";
}
