using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class DisplayEntityStateDeserializer : BaseStateDeserializer<DisplayEntityState>
{
    public override string TargetDomain { get; } = "display";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
