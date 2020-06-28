using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Fan;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Fan
{
    public interface IFanMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<IFanMqttEntityConfigurationBuilder, IFan, IFanEntityDefinition, FanEntityDefinitionBuilder, IFanMqttEntityConfiguration>
    {
    }
}
