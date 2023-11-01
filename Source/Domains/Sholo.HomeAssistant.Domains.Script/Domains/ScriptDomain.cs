namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class ScriptDomain : BaseDomain
{
    public override string Name { get; } = "script";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/script/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/script/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/script/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/script/strings.json";
}
