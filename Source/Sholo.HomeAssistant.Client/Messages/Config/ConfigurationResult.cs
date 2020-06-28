using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Config
{
    [PublicAPI]
    public class ConfigurationResult
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Elevation { get; set; }
        public UnitSystemConfiguration UnitSystem { get; set; } = new UnitSystemConfiguration();
        public string LocationName { get; set; }
        public string TimeZone { get; set; }
        public string[] Components { get; set; }
        public string ConfigDir { get; set; }
        public string[] WhitelistExternalDirs { get; set; }
        public string Version { get; set; }
        public ConfigMode ConfigSource { get; set; }
        public bool SafeMode { get; set; }
    }
}
