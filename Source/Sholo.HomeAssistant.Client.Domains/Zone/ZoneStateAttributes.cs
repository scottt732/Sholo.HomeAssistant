using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Zone
{
    [PublicAPI]
    public class ZoneStateAttributes
    {
        public bool Editable { get; set; }
        public string FriendlyName { get; set; }
        public bool Hidden { get; set; }
        public string Icon { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? Passive { get; set; }
        public int? Radius { get; set; }
    }
}
