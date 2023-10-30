using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class DeviceTrackerStateAttributes
{
    public double? Altitude { get; set; }
    public string ConnectionState { get; set; } = null!;
    public string EntityPicture { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public int? GpsAccuracy { get; set; }
    public string Icon { get; set; } = null!;
    public bool? IsDead { get; set; }
    public bool? IsLost { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string RingState { get; set; } = null!;
    public string SourceType { get; set; } = null!;
    public string TileIdentifier { get; set; } = null!;
    public string TileName { get; set; } = null!;
    public string VoipState { get; set; } = null!;

    [JsonProperty("_is_guest_by_uap")]
    public bool? IsGuestByUap { get; set; }

    public string ApMac { get; set; } = null!;
    public bool? Authorized { get; set; }
    public string Essid { get; set; } = null!;
    public string Ip { get; set; } = null!;

    // ReSharper disable once InconsistentNaming
    public bool? Is11r { get; set; }
    public bool? IsGuest { get; set; }
    public bool? IsWired { get; set; }
    public string Mac { get; set; } = null!;
    public string Oui { get; set; } = null!;
    public bool? QosPolicyApplied { get; set; }
    public string Radio { get; set; } = null!;
    public string RadioProto { get; set; } = null!;
    public string SiteId { get; set; } = null!;
    public int? Vlan { get; set; }
    public string Hostname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool? Noted { get; set; }
    public int? BatteryLevel { get; set; }
    public int? VerticalAccuracy { get; set; }
    public int? Speed { get; set; }
    public int? BatteryStatus { get; set; }
    public string Tid { get; set; } = null!;
    public bool? Restored { get; set; }
    public int? SupportedFeatures { get; set; }
}
