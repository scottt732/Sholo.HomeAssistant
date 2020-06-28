using System;

namespace Sholo.HomeAssistant.Client.Events.TimeChanged
{
    public class TimeChangedPayload
    {
        public DateTimeOffset Now { get; set; }
    }
}
