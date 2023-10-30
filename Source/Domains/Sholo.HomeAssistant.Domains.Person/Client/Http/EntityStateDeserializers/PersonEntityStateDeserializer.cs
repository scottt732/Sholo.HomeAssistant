using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class PersonEntityStateDeserializer : BaseStateDeserializer<PersonEntityState>
{
    public override string TargetDomain { get; } = "person";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
