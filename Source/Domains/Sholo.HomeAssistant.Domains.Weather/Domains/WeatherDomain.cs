namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class WeatherDomain : BaseDomain
{
    public override string Name { get; } = "weather";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/weather/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/weather/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/weather/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/weather/strings.json";
}
