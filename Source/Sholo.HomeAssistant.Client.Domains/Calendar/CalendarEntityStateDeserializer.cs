using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Calendar
{
    public class CalendarEntityStateDeserializer : BaseStateDeserializer<CalendarEntityState>
    {
        public override string TargetDomain { get; } = "calendar";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}