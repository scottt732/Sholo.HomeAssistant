using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class ClimateEntityStateDeserializer : BaseStateDeserializer<ClimateEntityState>
{
    public override string TargetDomain { get; } = "climate";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
