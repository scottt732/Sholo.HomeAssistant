using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.BinarySensor;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.BinarySensor
{
    public interface IBinarySensorMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<IBinarySensorMqttEntityConfigurationBuilder, IBinarySensor, IBinarySensorEntityDefinition, BinarySensorEntityDefinitionBuilder, IBinarySensorMqttEntityConfiguration>
    {
    }
}
