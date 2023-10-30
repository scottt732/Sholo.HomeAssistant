using System;

namespace Sholo.HomeAssistant.Client.WebSockets.Events;

[PublicAPI]
public class EventData
{
    public DateTimeOffset TimeFired { get; set; }
    public string Origin { get; set; } = null!;
    public string EventType { get; set; } = null!;
}

[PublicAPI]
public class EventData<TPayload> : EventData
{
    public TPayload Data { get; set; } = default(TPayload)!;
}
