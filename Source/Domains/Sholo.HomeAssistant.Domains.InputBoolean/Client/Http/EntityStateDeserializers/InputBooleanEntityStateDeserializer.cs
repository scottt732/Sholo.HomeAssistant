using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class InputBooleanEntityStateDeserializer : BaseStateDeserializer<InputBooleanEntityState>
{
    public override string TargetDomain { get; } = "input_boolean";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
