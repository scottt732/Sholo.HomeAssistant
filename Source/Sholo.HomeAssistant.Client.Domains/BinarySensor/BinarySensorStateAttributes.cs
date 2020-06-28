using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.BinarySensor
{
    [PublicAPI]
    public class BinarySensorStateAttributes
    {
        public string DeviceClass { get; set; }
        public string FriendlyName { get; set; }
        public string Attribution { get; set; }
        public string Icon { get; set; }
        public string NewestVersion { get; set; }
        public string ReleaseNotes { get; set; }
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
        public bool? Value { get; set; }
        public string ValueId { get; set; }
        public bool? WriteOnly { get; set; }
        public bool? Restored { get; set; }
        public int? SupportedFeatures { get; set; }
        public int? Battery { get; set; }
        public bool? BatteryCharging { get; set; }
        public int? BatteryLevel { get; set; }
        public bool? Charging { get; set; }
        public string LastSeen { get; set; }
        public bool? Motion { get; set; }
    }
}
