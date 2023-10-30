using System;

namespace Sholo.HomeAssistant.Client.WebSockets.Events.TimeChanged;

public class TimeChangedPayload
{
    public DateTimeOffset Now { get; set; }
}
