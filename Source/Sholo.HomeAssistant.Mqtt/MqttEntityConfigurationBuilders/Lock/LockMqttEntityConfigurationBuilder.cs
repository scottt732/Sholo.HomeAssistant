using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.CommandHandlers.Lock;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Lock;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Lock
{
    public class LockMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<LockMqttEntityConfigurationBuilder, ILockMqttEntityConfigurationBuilder, ILock, ILockEntityDefinition, LockEntityDefinitionBuilder, ILockMqttEntityConfiguration>,
        ILockMqttEntityConfigurationBuilder
    {
        public override ILockMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => WithStateChangeHandler(new LockStateChangeHandler());

        public override ILockMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => WithCommandHandler(new LockCommandHandler());

        protected override ILockMqttEntityConfiguration Build(
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
            => new LockMqttEntityConfiguration(
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
            );

        public LockMqttEntityConfigurationBuilder()
            : base(ComponentType.Lock)
        {
        }
    }
}
