using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Lock
{
    public interface ILockMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<ILockMqttEntityConfigurationBuilder, ILock, ILockEntityDefinition, LockEntityDefinitionBuilder, ILockMqttEntityConfiguration>
    {
    }
}
