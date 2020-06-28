using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.DeviceTracker
{
    [PublicAPI]
    public enum DeviceTrackerStateValue
    {
        Unavailable,
        Unknown,
        Home,
        NotHome,
    }
}
