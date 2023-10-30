using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public interface ILockMqttEntityConfigurationBuilder
    : IMqttStatefulEntityConfigurationBuilder<ILockMqttEntityConfigurationBuilder, ILock, ILockEntityDefinition, LockEntityDefinitionBuilder, ILockMqttEntityConfiguration>
{
}
