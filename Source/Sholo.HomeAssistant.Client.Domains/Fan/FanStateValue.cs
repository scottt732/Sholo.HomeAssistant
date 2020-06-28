using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Fan
{
    [PublicAPI]
    public enum FanStateValue
    {
        Unavailable,
        Off,
        On
    }
}
