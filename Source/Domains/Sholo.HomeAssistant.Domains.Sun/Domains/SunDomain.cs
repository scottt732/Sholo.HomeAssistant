namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class SunDomain : BaseDomain
{
    public override string Name { get; } = "sun";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/sun/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/sun/manifest.json";
    public override string? StringsJsonPath { get; } = "homeassistant/components/sun/strings.json";
}
