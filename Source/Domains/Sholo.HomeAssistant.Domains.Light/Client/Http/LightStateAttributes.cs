namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class LightStateAttributes
{
    public string[] EffectList { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public int MaxMireds { get; set; }
    public int MinMireds { get; set; }
    public int? SupportedFeatures { get; set; }
    public int? Brightness { get; set; }
    public string Effect { get; set; } = null!;
    public double[] HsColor { get; set; } = null!;
    public int[] RgbColor { get; set; } = null!;
    public double[] XyColor { get; set; } = null!;
    public bool? IsHueGroup { get; set; }
    public string DeviceId { get; set; } = null!;
    public string LastSeen { get; set; } = null!;
    public string Type { get; set; } = null!;
}
