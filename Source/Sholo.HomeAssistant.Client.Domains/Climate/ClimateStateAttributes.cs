using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Climate
{
    [PublicAPI]
    public class ClimateStateAttributes
    {
        public string[] FanModes { get; set; }
        public string FriendlyName { get; set; }
        public string[] HvacModes { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public string[] PresetModes { get; set; }
        public bool Restored { get; set; }
        public int SupportedFeatures { get; set; }
    }
}
