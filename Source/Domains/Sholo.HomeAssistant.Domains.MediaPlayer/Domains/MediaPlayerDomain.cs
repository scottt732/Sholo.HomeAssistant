namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class MediaPlayerDomain : BaseDomain
{
    public override string Name { get; } = "media_player";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/media_player/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/media_player/manifest.json";
    public override string? ServicesYamlPath { get; } = "homeassistant/components/media_player/services.yaml";
    public override string? StringsJsonPath { get; } = "homeassistant/components/media_player/strings.json";
}
