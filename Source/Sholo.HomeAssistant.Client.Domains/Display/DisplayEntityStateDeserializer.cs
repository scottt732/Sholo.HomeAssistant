using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Display
{
    public class DisplayEntityStateDeserializer : BaseStateDeserializer<DisplayEntityState>
    {
        public override string TargetDomain { get; } = "display";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}