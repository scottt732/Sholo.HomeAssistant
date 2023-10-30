using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class GroupEntityStateDeserializer : BaseStateDeserializer<GroupEntityState>
{
    public override string TargetDomain { get; } = "group";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
