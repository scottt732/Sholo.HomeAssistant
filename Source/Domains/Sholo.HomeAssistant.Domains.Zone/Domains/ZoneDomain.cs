namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class ZoneDomain : BaseDomain
{
    public override string Name { get; } = "zone";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/zone/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/zone/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/zone/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/zone/strings.json";
}
