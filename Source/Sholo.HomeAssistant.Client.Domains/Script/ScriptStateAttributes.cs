using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Script
{
    [PublicAPI]
    public class ScriptStateAttributes
    {
        public string FriendlyName { get; set; }
        public string LastTriggered { get; set; }
        public bool CanCancel { get; set; }
    }
}
