using JetBrains.Annotations;
using Sholo.HomeAssistant.DeviceClasses;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Sensor
{
    [PublicAPI]
    public interface ISensorEntityDefinitionBuilder<out TSelf> : ICoreSensorEntityDefinitionBuilder<TSelf, ISensorEntityDefinition, SensorDeviceClass>
        where TSelf : ISensorEntityDefinitionBuilder<TSelf>
    {
        TSelf WithIcon(string icon);
        TSelf WithUnitOfMeasurement(string unitOfMeasurement);
    }
}
