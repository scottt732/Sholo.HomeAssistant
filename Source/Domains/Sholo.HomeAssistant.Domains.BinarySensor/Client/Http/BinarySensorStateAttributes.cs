namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class BinarySensorStateAttributes
{
    public string DeviceClass { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public string Attribution { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string NewestVersion { get; set; } = null!;
    public string ReleaseNotes { get; set; } = null!;
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
    public bool? Value { get; set; }
    public string ValueId { get; set; } = null!;
    public bool? WriteOnly { get; set; }
    public bool? Restored { get; set; }
    public int? SupportedFeatures { get; set; }
    public int? Battery { get; set; }
    public bool? BatteryCharging { get; set; }
    public int? BatteryLevel { get; set; }
    public bool? Charging { get; set; }
    public string LastSeen { get; set; } = null!;
    public bool? Motion { get; set; }
}
