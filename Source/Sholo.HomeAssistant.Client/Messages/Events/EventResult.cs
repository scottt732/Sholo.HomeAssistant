using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Events
{
    [PublicAPI]
    public class EventResult
    {
        public string Event { get; set; }
        public int ListenerCount { get; set; }
    }
}
