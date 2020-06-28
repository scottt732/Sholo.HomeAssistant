using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Domains.DeviceTracker
{
    [PublicAPI]
    public class DeviceTrackerStateAttributes
    {
        public double? Altitude { get; set; }
        public string ConnectionState { get; set; }
        public string EntityPicture { get; set; }
        public string FriendlyName { get; set; }
        public int? GpsAccuracy { get; set; }
        public string Icon { get; set; }
        public bool? IsDead { get; set; }
        public bool? IsLost { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string RingState { get; set; }
        public string SourceType { get; set; }
        public string TileIdentifier { get; set; }
        public string TileName { get; set; }
        public string VoipState { get; set; }

        [JsonProperty("_is_guest_by_uap")]
        public bool? IsGuestByUap { get; set; }

        public string ApMac { get; set; }
        public bool? Authorized { get; set; }
        public string Essid { get; set; }
        public string Ip { get; set; }
        public bool? Is11r { get; set; }
        public bool? IsGuest { get; set; }
        public bool? IsWired { get; set; }
        public string Mac { get; set; }
        public string Oui { get; set; }
        public bool? QosPolicyApplied { get; set; }
        public string Radio { get; set; }
        public string RadioProto { get; set; }
        public string SiteId { get; set; }
        public int? Vlan { get; set; }
        public string Hostname { get; set; }
        public string Name { get; set; }
        public bool? Noted { get; set; }
        public int? BatteryLevel { get; set; }
        public int? VerticalAccuracy { get; set; }
        public int? Speed { get; set; }
        public int? BatteryStatus { get; set; }
        public string Tid { get; set; }
        public bool? Restored { get; set; }
        public int? SupportedFeatures { get; set; }
    }
}
