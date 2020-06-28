using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock
{
    public class LockMqttEntityConfiguration : BaseMqttStatefulEntityConfiguration<ILock, ILockEntityDefinition>, ILockMqttEntityConfiguration
    {
        public LockMqttEntityConfiguration(
            ILock entity,
            ILockEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<ILock, ILockEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<ILock, ILockEntityDefinition>[] stateChangeHandlers
        )
            : base(
                entity,
                entityDefinition,
                discoveryTopic,
                discoveryMessage,
                deleteMessage,
                discoveryMessageQualityOfServiceLevel,
                retainDiscoveryMessage,
                commandHandlers,
                stateMessageQualityOfServiceLevel,
                retainStateMessages,
                stateChangeHandlers
            )
        {
        }
    }
}
