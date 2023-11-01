namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class LockDomain : BaseDomain
{
    public override string Name { get; } = "lock";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/lock/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/lock.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/lock/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/lock/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/lock/strings.json";
}
