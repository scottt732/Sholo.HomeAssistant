using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Switch
{
    public class SwitchEntityStateDeserializer : BaseStateDeserializer<SwitchEntityState>
    {
        public override string TargetDomain { get; } = "switch";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}