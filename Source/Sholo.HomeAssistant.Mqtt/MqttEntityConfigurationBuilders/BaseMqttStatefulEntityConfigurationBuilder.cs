using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders
{
    public abstract class BaseMqttStatefulEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
        : BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>,
            IMqttStatefulEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
        where TSelf : BaseMqttStatefulEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>, TSelfInterface
        where TSelfInterface : IMqttStatefulEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>,
            IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
        where TEntityDefinitionBuilder : class, IStatefulEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    {
        private MqttQualityOfServiceLevel? StateMessageQualityOfServiceLevel { get; set; }
        private bool? RetainStateMessages { get; set; }

        private List<IStateChangeHandler<TEntity, TEntityDefinition>> StateChangeHandlers { get; } = new List<IStateChangeHandler<TEntity, TEntityDefinition>>();

        public TSelfInterface WithStateMessageQualityOfServiceLevel(MqttQualityOfServiceLevel? qualityOfServiceLevel)
        {
            StateMessageQualityOfServiceLevel = qualityOfServiceLevel;
            return (TSelf)this;
        }

        public TSelfInterface WithRetainedStateMessages(bool retainStateMessages = true)
        {
            RetainStateMessages = retainStateMessages;
            return (TSelf)this;
        }

        public abstract TSelfInterface WithDefaultStateChangeHandlers();

        public TSelfInterface WithStateChangeHandler(
            Func<TEntityDefinition, TEntity, string> stateMessagePayloadSelector,
            Func<TEntity, IObservable<Unit>> stateChangeDetectionSelector
        )
        {
            StateChangeHandlers.Add(
                new DelegateValueStateChangeHandler<TEntity, TEntityDefinition>(stateMessagePayloadSelector, stateChangeDetectionSelector)
            );
            return (TSelf)this;
        }

        public TSelfInterface WithStateChangeHandler(IStateChangeHandler<TEntity, TEntityDefinition> stateChangeHandler)
        {
            StateChangeHandlers.Add(stateChangeHandler);
            return (TSelf)this;
        }

        public override TMqttEntityConfiguration Build()
            => Build(
                Entity ?? throw new InvalidOperationException("You must set the entity"),
                EntityDefinition ?? throw new InvalidOperationException("You must set the entity definition"),
                DiscoveryTopic ?? throw new InvalidOperationException("You must set the discovery topic"),
                DiscoveryMessage ?? CreateDefaultDiscoveryMessage(EntityDefinition),
                DeleteMessage ?? CreateDefaultDeleteMessage(),
                DiscoveryMessageQualityOfServiceLevel,
                RetainDiscoveryMessages,
                CommandHandlers.ToArray(),
                StateMessageQualityOfServiceLevel,
                RetainStateMessages ?? false,
                StateChangeHandlers.ToArray()
            );

        protected abstract TMqttEntityConfiguration Build(
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
        );

        protected BaseMqttStatefulEntityConfigurationBuilder(ComponentType componentType)
            : base(componentType)
        {
        }
    }
}
