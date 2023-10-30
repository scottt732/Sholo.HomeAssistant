using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class BinarySensorEntityStateDeserializer : BaseStateDeserializer<BinarySensorEntityState>
{
    public override string TargetDomain { get; } = "binary_sensor";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
