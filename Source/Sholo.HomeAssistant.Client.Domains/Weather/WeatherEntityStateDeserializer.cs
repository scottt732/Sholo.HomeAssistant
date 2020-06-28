using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Weather
{
    public class WeatherEntityStateDeserializer : BaseStateDeserializer<WeatherEntityState>
    {
        public override string TargetDomain { get; } = "weather";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}