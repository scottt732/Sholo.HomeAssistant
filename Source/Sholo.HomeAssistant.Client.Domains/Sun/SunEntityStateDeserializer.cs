using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Sun
{
    public class SunEntityStateDeserializer : BaseStateDeserializer<SunEntityState>
    {
        public override string TargetDomain { get; } = "sun";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}