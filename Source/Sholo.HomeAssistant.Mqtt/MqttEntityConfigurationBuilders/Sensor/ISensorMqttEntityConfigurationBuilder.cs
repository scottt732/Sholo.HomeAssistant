using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Sensor;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Sensor
{
    public interface ISensorMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<ISensorMqttEntityConfigurationBuilder, ISensor, ISensorEntityDefinition, SensorEntityDefinitionBuilder, ISensorMqttEntityConfiguration>
    {
    }
}
