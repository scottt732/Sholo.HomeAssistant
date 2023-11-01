namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public class EventDomain : BaseDomain
{
    public override string Name { get; } = "event";
    public override Uri? DocumentationUri { get; } = new("https://www.home-assistant.io/integrations/event/", UriKind.Absolute);
    public override Uri? MqttDocumentationUri { get; } = new("https://www.home-assistant.io/integrations/event.mqtt/", UriKind.Absolute);
    public override string ManifestJsonPath { get; } = "homeassistant/components/event/manifest.json";
    public override string? StringsJsonPath { get; } = "homeassistant/components/event/strings.json";
}
