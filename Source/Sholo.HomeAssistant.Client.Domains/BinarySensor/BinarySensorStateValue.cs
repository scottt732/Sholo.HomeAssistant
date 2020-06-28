using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.BinarySensor
{
    [PublicAPI]
    public enum BinarySensorStateValue
    {
        Unavailable,
        Off,
        On
    }
}
