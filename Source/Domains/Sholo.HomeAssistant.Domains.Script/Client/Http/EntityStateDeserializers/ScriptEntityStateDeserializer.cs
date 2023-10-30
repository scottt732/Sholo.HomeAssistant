using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class ScriptEntityStateDeserializer : BaseStateDeserializer<ScriptEntityState>
{
    public override string TargetDomain { get; } = "script";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
