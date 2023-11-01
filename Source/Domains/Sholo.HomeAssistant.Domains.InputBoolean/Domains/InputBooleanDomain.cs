namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class InputBooleanDomain : BaseDomain
{
    public override string Name { get; } = "input_boolean";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/input_boolean/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/input_boolean/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/input_boolean/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/input_boolean/strings.json";
}
