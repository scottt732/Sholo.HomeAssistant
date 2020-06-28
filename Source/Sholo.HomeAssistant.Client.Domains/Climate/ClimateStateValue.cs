using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Climate
{
    [PublicAPI]
    public enum ClimateStateValue
    {
        Unavailable,
        Cool,
        Heat
    }
}
