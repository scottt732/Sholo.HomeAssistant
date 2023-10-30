using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class ZoneEntityStateDeserializer : BaseStateDeserializer<ZoneEntityState>
{
    public override string TargetDomain { get; } = "zone";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
