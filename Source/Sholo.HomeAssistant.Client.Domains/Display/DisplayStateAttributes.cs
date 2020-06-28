using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Display
{
    [PublicAPI]
    public class DisplayStateAttributes
    {
        public bool BatteryCharging { get; set; }
        public int BatteryLevel { get; set; }
        public int? Brightness { get; set; }
        public string DeviceId { get; set; }
        public string DisplayResolution { get; set; }
        public string FriendlyName { get; set; }
        public bool KioskMode { get; set; }
        public string MacAddress { get; set; }
        public bool MaintenanceMode { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Page { get; set; }
        public bool ScreensaverOn { get; set; }
        public int SupportedFeatures { get; set; }
        public string Version { get; set; }
    }
}
