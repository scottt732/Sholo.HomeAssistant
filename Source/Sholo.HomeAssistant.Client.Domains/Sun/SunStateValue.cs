using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Sun
{
    [PublicAPI]
    public enum SunStateValue
    {
        Unavailable,
        AboveHorizon,
        BelowHorizon
    }
}
