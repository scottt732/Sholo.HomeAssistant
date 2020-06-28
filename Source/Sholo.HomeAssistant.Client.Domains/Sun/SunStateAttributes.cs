using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Sun
{
    [PublicAPI]
    public class SunStateAttributes
    {
        public double Azimuth { get; set; }
        public double Elevation { get; set; }
        public string FriendlyName { get; set; }
        public string NextDawn { get; set; }
        public string NextDusk { get; set; }
        public string NextMidnight { get; set; }
        public string NextNoon { get; set; }
        public string NextRising { get; set; }
        public string NextSetting { get; set; }
        public bool Rising { get; set; }
    }
}
