using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Automation
{
    [PublicAPI]
    public enum AutomationStateValue
    {
        Unavailable,
        On,
        Off
    }
}
