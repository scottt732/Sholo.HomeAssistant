namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class CalendarDomain : BaseDomain
{
    public override string Name { get; } = "calendar";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/calendar/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/calendar/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/calendar/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/calendar/strings.json";
}
