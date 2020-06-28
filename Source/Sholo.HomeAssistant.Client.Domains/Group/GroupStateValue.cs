using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Group
{
    [PublicAPI]
    public enum GroupStateValue
    {
        Unavailable,
        Locked,
        Off,
        On,
        Unknown,
        Home
    }
}
