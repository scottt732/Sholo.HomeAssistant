using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Automation
{
    [PublicAPI]
    public class AutomationStateAttributes
    {
        public string FriendlyName { get; set; }
        public string LastTriggered { get; set; }
        public string Id { get; set; }
    }
}
