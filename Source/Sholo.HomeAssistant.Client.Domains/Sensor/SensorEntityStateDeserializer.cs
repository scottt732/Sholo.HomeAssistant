using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Sensor
{
    public class SensorEntityStateDeserializer : BaseStateDeserializer<SensorEntityState>
    {
        public override string TargetDomain { get; } = "sensor";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}