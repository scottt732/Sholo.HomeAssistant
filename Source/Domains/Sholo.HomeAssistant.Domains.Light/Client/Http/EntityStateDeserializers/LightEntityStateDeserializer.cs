using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

[PublicAPI]
public class LightEntityStateDeserializer : BaseStateDeserializer<LightEntityState>
{
    public override string TargetDomain { get; } = "light";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
