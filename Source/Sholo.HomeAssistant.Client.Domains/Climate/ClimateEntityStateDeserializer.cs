using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Climate
{
    public class ClimateEntityStateDeserializer : BaseStateDeserializer<ClimateEntityState>
    {
        public override string TargetDomain { get; } = "climate";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}