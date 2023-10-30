using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class FanEntityStateDeserializer : BaseStateDeserializer<FanEntityState>
{
    public override string TargetDomain { get; } = "fan";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
