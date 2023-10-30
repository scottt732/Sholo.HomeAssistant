namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class DeviceTriggerStateAttributes
{
    public string FriendlyName { get; set; } = null!;
    public string LastTriggered { get; set; } = null!;
    public string Id { get; set; } = null!;
}
