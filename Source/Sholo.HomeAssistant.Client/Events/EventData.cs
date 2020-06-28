using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Events
{
    [PublicAPI]
    public class EventData
    {
        public DateTimeOffset TimeFired { get; set; }
        public string Origin { get; set; }
        public string EventType { get; set; }
    }

    [PublicAPI]
    public class EventData<TPayload> : EventData
    {
        public TPayload Data { get; set; }
    }
}
