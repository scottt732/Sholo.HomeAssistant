using System;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Config;

[PublicAPI]
public class ConfigurationResult
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Elevation { get; set; }
    public UnitSystemConfiguration UnitSystem { get; set; } = new();
    public string LocationName { get; set; } = null!;
    public string TimeZone { get; set; } = null!;
    public string[] Components { get; set; } = null!;
    public string ConfigDir { get; set; } = null!;
    public string[] WhitelistExternalDirs { get; set; } = null!;
    public string[] AllowlistExternalDirs { get; set; } = null!;
    public string[] AllowlistExternalUrls { get; set; } = null!;
    public string Version { get; set; } = null!;
    public ConfigMode ConfigSource { get; set; }
    public bool SafeMode { get; set; }
    public string State { get; set; } = null!;
    public Uri InternalUrl { get; set; } = null!;
    public Uri ExternalUrl { get; set; } = null!;
    public string Currency { get; set; } = null!;
}
