namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class GroupDomain : BaseDomain
{
    public override string Name { get; } = "group";
    public override Uri? DocumentationUri { get; } = new Uri("https://www.home-assistant.io/integrations/group/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/group/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/group/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/group/strings.json";
}
