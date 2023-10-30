namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class ClimateStateAttributes
{
    public string[] FanModes { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public string[] HvacModes { get; set; } = null!;
    public int MaxTemp { get; set; }
    public int MinTemp { get; set; }
    public string[] PresetModes { get; set; } = null!;
    public bool Restored { get; set; }
    public int SupportedFeatures { get; set; }
}
