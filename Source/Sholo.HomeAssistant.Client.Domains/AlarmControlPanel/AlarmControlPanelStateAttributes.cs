using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.AlarmControlPanel
{
    [PublicAPI]
    public class AlarmControlPanelStateAttributes
    {
        public string /* Ambiguous */ ChangedBy { get; set; }
        public bool CodeArmRequired { get; set; }
        public string CodeFormat { get; set; }
        public string FriendlyName { get; set; }
        public int SupportedFeatures { get; set; }
    }
}
