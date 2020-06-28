using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Light
{
    [PublicAPI]
    public enum LightStateValue
    {
        Unavailable,
        Off,
        On
    }
}
