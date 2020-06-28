using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor
{
    public class BinarySensorEntityDefinition : BaseCoreSensorEntityDefinition, IBinarySensorEntityDefinition
    {
        public BinarySensorDeviceClass? DeviceClass { get; internal set; }
        public int? OffDelay { get; internal set; }
        public string PayloadOff { get; internal set; }
        public string PayloadOn { get; internal set; }
    }
}
