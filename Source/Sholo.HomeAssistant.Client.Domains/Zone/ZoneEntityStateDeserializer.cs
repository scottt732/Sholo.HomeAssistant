using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Zone
{
    public class ZoneEntityStateDeserializer : BaseStateDeserializer<ZoneEntityState>
    {
        public override string TargetDomain { get; } = "zone";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}