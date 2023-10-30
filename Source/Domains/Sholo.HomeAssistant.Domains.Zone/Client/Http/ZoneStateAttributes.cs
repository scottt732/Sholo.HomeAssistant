namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class ZoneStateAttributes
{
    public bool Editable { get; set; }
    public string FriendlyName { get; set; } = null!;
    public bool Hidden { get; set; }
    public string Icon { get; set; } = null!;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public bool? Passive { get; set; }
    public int? Radius { get; set; }
}
