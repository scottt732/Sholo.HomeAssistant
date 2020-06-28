using System.Collections.Generic;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Light
{
    [PublicAPI]
    public class LightEntityStateDeserializer : BaseStateDeserializer<LightEntityState>
    {
        public override string TargetDomain { get; } = "light";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}
