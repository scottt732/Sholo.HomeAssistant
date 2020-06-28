using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Switch
{
    public interface ISwitchMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<ISwitchMqttEntityConfigurationBuilder, ISwitch, ISwitchEntityDefinition, SwitchEntityDefinitionBuilder, ISwitchMqttEntityConfiguration>
    {
    }
}
