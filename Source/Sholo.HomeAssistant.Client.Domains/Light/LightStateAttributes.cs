using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Light
{
    [PublicAPI]
    public class LightStateAttributes
    {
        public string[] EffectList { get; set; }
        public string FriendlyName { get; set; }
        public int MaxMireds { get; set; }
        public int MinMireds { get; set; }
        public int? SupportedFeatures { get; set; }
        public int? Brightness { get; set; }
        public string Effect { get; set; }
        public double[] HsColor { get; set; }
        public int[] RgbColor { get; set; }
        public double[] XyColor { get; set; }
        public bool? IsHueGroup { get; set; }
        public string DeviceID { get; set; }
        public string LastSeen { get; set; }
        public string Type { get; set; }
    }
}
