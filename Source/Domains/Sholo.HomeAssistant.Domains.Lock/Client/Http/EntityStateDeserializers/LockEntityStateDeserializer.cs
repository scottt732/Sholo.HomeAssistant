using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class LockEntityStateDeserializer : BaseStateDeserializer<LockEntityState>
{
    public override string TargetDomain { get; } = "lock";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
