using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class SensorEntityStateDeserializer : BaseStateDeserializer<SensorEntityState>
{
    public override string TargetDomain { get; } = "sensor";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
