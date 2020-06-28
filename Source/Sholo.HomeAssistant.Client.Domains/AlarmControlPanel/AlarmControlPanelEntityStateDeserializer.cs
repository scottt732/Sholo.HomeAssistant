using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.AlarmControlPanel
{
    public class AlarmControlPanelEntityStateDeserializer : BaseStateDeserializer<AlarmControlPanelEntityState>
    {
        public override string TargetDomain { get; } = "alarm_control_panel";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}