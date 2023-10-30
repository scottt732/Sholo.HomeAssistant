using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class SwitchEntityStateDeserializer : BaseStateDeserializer<SwitchEntityState>
{
    public override string TargetDomain { get; } = "switch";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
