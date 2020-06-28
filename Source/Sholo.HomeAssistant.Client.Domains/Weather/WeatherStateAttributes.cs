using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Weather
{
    [PublicAPI]
    public class WeatherStateAttributes
    {
        public string FriendlyName { get; set; }
        public bool Restored { get; set; }
        public int SupportedFeatures { get; set; }
    }
}
