namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class CoverDomain : BaseDomain
{
    public override string Name { get; } = "cover";
    public override string ManifestJsonPath { get; } = "homeassistant/components/cover/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/cover/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/cover/strings.json";
}
