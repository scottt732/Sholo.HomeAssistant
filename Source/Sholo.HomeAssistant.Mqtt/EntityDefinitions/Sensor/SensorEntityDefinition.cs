using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor
{
    public class SensorEntityDefinition : BaseCoreSensorEntityDefinition, ISensorEntityDefinition
    {
        public SensorDeviceClass? DeviceClass { get; internal set; }
        public string Icon { get; internal set; }
        public string UnitOfMeasurement { get; internal set; }
    }
}
