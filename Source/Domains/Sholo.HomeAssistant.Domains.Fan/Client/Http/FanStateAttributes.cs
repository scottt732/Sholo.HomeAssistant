namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class FanStateAttributes
{
    public string FriendlyName { get; set; } = null!;
    public string Speed { get; set; } = null!;
    public string[] SpeedList { get; set; } = null!;
    public int SupportedFeatures { get; set; }
}
