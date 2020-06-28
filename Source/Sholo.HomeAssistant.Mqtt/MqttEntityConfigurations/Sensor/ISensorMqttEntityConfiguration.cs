using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Sensor
{
    public interface ISensorMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ISensor, ISensorEntityDefinition>
    {
    }
}
