namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class DeviceTriggerDomain : BaseDomain
{
    public override string Name { get; } = "device_trigger";
    public override string? MqttValue { get; } = "trigger";
    public override string? MqttDiscoveryValue { get; } = "device_automation";
    public override Uri? DocumentationUri { get; } = new Uri("https://www.home-assistant.io/docs/automation/trigger/#device-triggers", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new Uri("https://www.home-assistant.io/integrations/device_trigger.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/device_automation/manifest.json";
}
