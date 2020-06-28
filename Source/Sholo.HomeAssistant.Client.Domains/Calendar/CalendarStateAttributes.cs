using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Calendar
{
    [PublicAPI]
    public class CalendarStateAttributes
    {
        public bool? AllDay { get; set; }
        public string Description { get; set; }
        public string EndTime { get; set; }
        public string FriendlyName { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public bool OffsetReached { get; set; }
        public string StartTime { get; set; }
    }
}
