using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

[PublicAPI]
public class CalendarEntityStateDeserializer : BaseStateDeserializer<CalendarEntityState>
{
    public override string TargetDomain { get; } = "calendar";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
