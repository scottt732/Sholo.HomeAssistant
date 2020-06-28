using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Fan
{
    public class FanEntityStateDeserializer : BaseStateDeserializer<FanEntityState>
    {
        public override string TargetDomain { get; } = "fan";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}