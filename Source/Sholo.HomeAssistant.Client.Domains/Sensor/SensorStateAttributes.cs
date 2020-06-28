using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Domains.Sensor
{
    [PublicAPI]
    public class SensorStateAttributes
    {
        public string Attribution { get; set; }
        public string EntityPicture { get; set; }
        public string FriendlyName { get; set; }
        public string Icon { get; set; }
        public object[] /* ambiguous */ Data { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string DeviceClass { get; set; }
        public string Confidence { get; set; }
        public string[] Types { get; set; }

        [JsonProperty("Battery State")]
        public string BatteryState { get; set; }

        [JsonProperty("Battery Level")]
        public int? BatteryLevel { get; set; }

        [JsonProperty("Allows VoIP")]
        public bool? AllowsVoIP { get; set; }

        [JsonProperty("Carrier ID")]
        public int? CarrierID { get; set; }

        [JsonProperty("Carrier Name")]
        public string CarrierName { get; set; }

        [JsonProperty("Current Radio Technology")]
        public string CurrentRadioTechnology { get; set; }

        [JsonProperty("ISO Country Code")]
        public string ISOCountryCode { get; set; }

        [JsonProperty("Mobile Country Code")]
        public int? MobileCountryCode { get; set; }

        [JsonProperty("Mobile Network Code")]
        public int? MobileNetworkCode { get; set; }

        [JsonProperty("Administrative Area")]
        public string AdministrativeArea { get; set; }

        [JsonProperty("Areas Of Interest")]
        public string AreasOfInterest { get; set; }

        public string Country { get; set; }

        [JsonProperty("Inland Water")]
        public string InlandWater { get; set; }

        public string Locality { get; set; }
        public double[] Location { get; set; }
        public string Name { get; set; }
        public string Ocean { get; set; }

        [JsonProperty("Postal Code")]
        public int? PostalCode { get; set; }

        [JsonProperty("Sub Administrative Area")]
        public string SubAdministrativeArea { get; set; }

        [JsonProperty("Sub Locality")]
        public string SubLocality { get; set; }

        [JsonProperty("Sub Thoroughfare")]
        public int? SubThoroughfare { get; set; }

        public string Thoroughfare { get; set; }

        [JsonProperty("Time Zone")]
        public string TimeZone { get; set; }

        public bool? Answered { get; set; }
        public string Category { get; set; }
        public string CreatedAt { get; set; }
        public string /* Ambiguous */ RecordingStatus { get; set; }
        public object[] /* ambiguous */ Repositories { get; set; }
        public int? ClassId { get; set; }
        public string Genre { get; set; }
        public string Help { get; set; }
        public int? Index { get; set; }
        public int? Instance { get; set; }
        public bool? IsPolled { get; set; }
        public string Label { get; set; }
        public long? LastUpdate { get; set; }
        public int? Max { get; set; }
        public int? Min { get; set; }
        public int? NodeId { get; set; }
        public bool? ReadOnly { get; set; }
        public string Type { get; set; }
        public string Units { get; set; }
        public string Value { get; set; }
        public string ValueId { get; set; }
        public string[] Values { get; set; }
        public bool? WriteOnly { get; set; }
        public bool? Restored { get; set; }
        public int? SupportedFeatures { get; set; }
        public string CurrentUser { get; set; }
        public string DeviceID { get; set; }
        public bool? FullyKiosk { get; set; }
        public int? Height { get; set; }
        public string LastSeen { get; set; }
        public string Path { get; set; }
        public string UserAgent { get; set; }
        public string Visibility { get; set; }
        public int? Width { get; set; }
        public string And { get; set; }
        public int? Count { get; set; }
        public string Or { get; set; }
        public string[] People { get; set; }
        public string /* Ambiguous */ Detail { get; set; }
    }
}
