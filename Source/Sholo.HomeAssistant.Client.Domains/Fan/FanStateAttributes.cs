using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Fan
{
    [PublicAPI]
    public class FanStateAttributes
    {
        public string FriendlyName { get; set; }
        public string Speed { get; set; }
        public string[] SpeedList { get; set; }
        public int SupportedFeatures { get; set; }
    }
}
