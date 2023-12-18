using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Events;

[PublicAPI]
public class FireEventCommand : BaseCommand
{
    public string EventType { get; }
    public IDictionary<string, object?>? EventData { get; }

    public FireEventCommand(string eventType, IDictionary<string, object?>? eventData = null)
    {
        MessageType = HomeAssistantWsMessageTypes.FireEvent;
        EventType = eventType;
        EventData = eventData;
    }
}
