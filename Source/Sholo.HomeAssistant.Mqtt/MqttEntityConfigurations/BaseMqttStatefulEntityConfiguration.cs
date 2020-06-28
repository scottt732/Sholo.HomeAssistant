using System;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations
{
    public abstract class BaseMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        : BaseMqttEntityConfiguration<TEntity, TEntityDefinition>, IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IStatefulEntityDefinition
    {
        public MqttQualityOfServiceLevel? StateMessageQualityOfServiceLevel { get; }
        public bool RetainStateMessages { get; }
        public IStateChangeHandler<TEntity, TEntityDefinition>[] StateChangeHandlers { get; }

        protected BaseMqttStatefulEntityConfiguration(
            TEntity entity,
            TEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<TEntity, TEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<TEntity, TEntityDefinition>[] stateChangeHandlers
        )
            : base(
                entity,
                entityDefinition,
                discoveryTopic,
                discoveryMessage,
                deleteMessage,
                discoveryMessageQualityOfServiceLevel,
                retainDiscoveryMessage,
                commandHandlers
            )
        {
            StateMessageQualityOfServiceLevel = stateMessageQualityOfServiceLevel;
            RetainStateMessages = retainStateMessages;
            StateChangeHandlers = stateChangeHandlers ?? throw new ArgumentNullException(nameof(stateChangeHandlers));
        }
    }
}
