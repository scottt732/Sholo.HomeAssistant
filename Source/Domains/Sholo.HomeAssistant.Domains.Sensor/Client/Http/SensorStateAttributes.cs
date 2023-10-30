using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class SensorStateAttributes
{
    public string Attribution { get; set; } = null!;
    public string EntityPicture { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public object[] /* ambiguous */ Data { get; set; } = null!;
    public string UnitOfMeasurement { get; set; } = null!;
    public string DeviceClass { get; set; } = null!;
    public string Confidence { get; set; } = null!;
    public string[] Types { get; set; } = null!;

    [JsonProperty("Battery State")]
    public string BatteryState { get; set; } = null!;

    [JsonProperty("Battery Level")]
    public int? BatteryLevel { get; set; }

    [JsonProperty("Allows VoIP")]
    public bool? AllowsVoIp { get; set; }

    [JsonProperty("Carrier ID")]
    public int? CarrierId { get; set; }

    [JsonProperty("Carrier Name")]
    public string CarrierName { get; set; } = null!;

    [JsonProperty("Current Radio Technology")]
    public string CurrentRadioTechnology { get; set; } = null!;

    [JsonProperty("ISO Country Code")]
    public string IsoCountryCode { get; set; } = null!;

    [JsonProperty("Mobile Country Code")]
    public string MobileCountryCode { get; set; } = null!;

    [JsonProperty("Mobile Network Code")]
    public string MobileNetworkCode { get; set; } = null!;

    [JsonProperty("Administrative Area")]
    public string AdministrativeArea { get; set; } = null!;

    [JsonProperty("Areas Of Interest")]
    public string AreasOfInterest { get; set; } = null!;

    public string Country { get; set; } = null!;

    [JsonProperty("Inland Water")]
    public string InlandWater { get; set; } = null!;

    public string Locality { get; set; } = null!;
    public double[] Location { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Ocean { get; set; } = null!;

    [JsonProperty("Postal Code")]
    public int? PostalCode { get; set; }

    [JsonProperty("Sub Administrative Area")]
    public string SubAdministrativeArea { get; set; } = null!;

    [JsonProperty("Sub Locality")]
    public string SubLocality { get; set; } = null!;

    [JsonProperty("Sub Thoroughfare")]
    public int? SubThoroughfare { get; set; }

    public string Thoroughfare { get; set; } = null!;

    [JsonProperty("Time Zone")]
    public string TimeZone { get; set; } = null!;

    public bool? Answered { get; set; }
    public string Category { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string /* Ambiguous */ RecordingStatus { get; set; } = null!;
    public object[] /* ambiguous */ Repositories { get; set; } = null!;
    public int? ClassId { get; set; }
    public string Genre { get; set; } = null!;
    public string Help { get; set; } = null!;
    public int? Index { get; set; }
    public int? Instance { get; set; }
    public bool? IsPolled { get; set; }
    public string Label { get; set; } = null!;
    public long? LastUpdate { get; set; }
    public int? Max { get; set; }
    public int? Min { get; set; }
    public int? NodeId { get; set; }
    public bool? ReadOnly { get; set; }
    public string Type { get; set; } = null!;
    public string Units { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string ValueId { get; set; } = null!;
    public string[] Values { get; set; } = null!;
    public bool? WriteOnly { get; set; }
    public bool? Restored { get; set; }
    public int? SupportedFeatures { get; set; }
    public string CurrentUser { get; set; } = null!;
    public string DeviceId { get; set; } = null!;
    public bool? FullyKiosk { get; set; }
    public int? Height { get; set; }
    public string LastSeen { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string UserAgent { get; set; } = null!;
    public string Visibility { get; set; } = null!;
    public int? Width { get; set; }
    public string And { get; set; } = null!;
    public int? Count { get; set; }
    public string Or { get; set; } = null!;
    public string[] People { get; set; } = null!;
    public string /* Ambiguous */ Detail { get; set; } = null!;
}
