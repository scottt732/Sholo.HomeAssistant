namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Events;

[PublicAPI]
public class EventResult
{
    public string Event { get; set; } = null!;
    public int ListenerCount { get; set; }
}
