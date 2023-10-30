namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class WeatherStateAttributes
{
    public string FriendlyName { get; set; } = null!;
    public bool Restored { get; set; }
    public int SupportedFeatures { get; set; }
}
