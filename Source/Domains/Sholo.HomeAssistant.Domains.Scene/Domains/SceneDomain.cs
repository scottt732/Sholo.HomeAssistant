namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class SceneDomain : BaseDomain
{
    public override string Name { get; } = "scene";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/scene/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/scene.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/scene/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/scene/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/scene/strings.json";
}
