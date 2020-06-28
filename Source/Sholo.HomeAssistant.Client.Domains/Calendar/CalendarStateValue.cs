using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Calendar
{
    [PublicAPI]
    public enum CalendarStateValue
    {
        Unavailable,
        On,
        Off
    }
}
