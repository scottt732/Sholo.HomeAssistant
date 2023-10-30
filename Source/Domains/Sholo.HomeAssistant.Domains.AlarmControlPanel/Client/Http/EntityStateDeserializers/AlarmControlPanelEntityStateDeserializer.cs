using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

[PublicAPI]
public class AlarmControlPanelEntityStateDeserializer : BaseStateDeserializer<AlarmControlPanelEntityState>
{
    public override string TargetDomain { get; } = "alarm_control_panel";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
