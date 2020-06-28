using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.BinarySensor
{
    public class BinarySensorEntityStateDeserializer : BaseStateDeserializer<BinarySensorEntityState>
    {
        public override string TargetDomain { get; } = "binary_sensor";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}