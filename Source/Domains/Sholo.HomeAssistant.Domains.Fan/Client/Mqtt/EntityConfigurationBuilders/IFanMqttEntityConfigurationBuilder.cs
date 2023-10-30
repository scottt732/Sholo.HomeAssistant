using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public interface IFanMqttEntityConfigurationBuilder
    : IMqttStatefulEntityConfigurationBuilder<IFanMqttEntityConfigurationBuilder, IFan, IFanEntityDefinition, FanEntityDefinitionBuilder, IFanMqttEntityConfiguration>
{
}
