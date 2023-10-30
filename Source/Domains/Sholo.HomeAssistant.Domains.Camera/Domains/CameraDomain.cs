namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class CameraDomain : BaseDomain
{
    public override string Name { get; } = "camera";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/camera/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/camera.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/camera/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/camera/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/camera/strings.json";
}
