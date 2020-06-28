using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Automation
{
    public class AutomationEntityStateDeserializer : BaseStateDeserializer<AutomationEntityState>
    {
        public override string TargetDomain { get; } = "automation";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}