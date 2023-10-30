using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class SunEntityStateDeserializer : BaseStateDeserializer<SunEntityState>
{
    public override string TargetDomain { get; } = "sun";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
