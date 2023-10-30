namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class DisplayStateAttributes
{
    public bool BatteryCharging { get; set; }
    public int BatteryLevel { get; set; }
    public int? Brightness { get; set; }
    public string DeviceId { get; set; } = null!;
    public string DisplayResolution { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public bool KioskMode { get; set; }
    public string MacAddress { get; set; } = null!;
    public bool MaintenanceMode { get; set; }
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Page { get; set; } = null!;
    public bool ScreensaverOn { get; set; }
    public int SupportedFeatures { get; set; }
    public string Version { get; set; } = null!;
}
