using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class WeatherEntityStateDeserializer : BaseStateDeserializer<WeatherEntityState>
{
    public override string TargetDomain { get; } = "weather";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
