namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class SunStateAttributes
{
    public double Azimuth { get; set; }
    public double Elevation { get; set; }
    public string FriendlyName { get; set; } = null!;
    public string NextDawn { get; set; } = null!;
    public string NextDusk { get; set; } = null!;
    public string NextMidnight { get; set; } = null!;
    public string NextNoon { get; set; } = null!;
    public string NextRising { get; set; } = null!;
    public string NextSetting { get; set; } = null!;
    public bool Rising { get; set; }
}
