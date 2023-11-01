namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class PersonDomain : BaseDomain
{
    public override string Name { get; } = "person";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/person/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/person/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/person/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/person/strings.json";
}
