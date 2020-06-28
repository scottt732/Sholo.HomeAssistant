using System;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations
{
    public abstract class BaseMqttEntityConfiguration<TEntity, TEntityDefinition> : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        public TEntity Entity { get; }
        public TEntityDefinition EntityDefinition { get; }
        public string DiscoveryTopic { get; }
        public MqttApplicationMessage DiscoveryMessage { get; }
        public MqttApplicationMessage DeleteMessage { get; }
        public MqttQualityOfServiceLevel? DiscoveryMessageQualityOfServiceLevel { get; }
        public bool RetainDiscoveryMessage { get; }

        public ICommandHandler<TEntity, TEntityDefinition>[] CommandHandlers { get; }

        protected BaseMqttEntityConfiguration(
            TEntity entity,
            TEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<TEntity, TEntityDefinition>[] commandHandlers
        )
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            EntityDefinition = entityDefinition ?? throw new ArgumentNullException(nameof(entityDefinition));
            DiscoveryTopic = discoveryTopic ?? throw new ArgumentNullException(nameof(discoveryTopic));
            DiscoveryMessage = discoveryMessage ?? throw new ArgumentNullException(nameof(discoveryMessage));
            DeleteMessage = deleteMessage ?? throw new ArgumentNullException(nameof(deleteMessage));
            DiscoveryMessageQualityOfServiceLevel = discoveryMessageQualityOfServiceLevel;
            RetainDiscoveryMessage = retainDiscoveryMessage;
            CommandHandlers = commandHandlers ?? throw new ArgumentNullException(nameof(commandHandlers));
        }
    }
}
