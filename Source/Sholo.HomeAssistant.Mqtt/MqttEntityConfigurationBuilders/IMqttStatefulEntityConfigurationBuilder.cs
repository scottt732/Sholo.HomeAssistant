using System;
using System.Reactive;
using JetBrains.Annotations;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders
{
    [PublicAPI]
    public interface IMqttStatefulEntityConfigurationBuilder<out TSelf, TEntity, TEntityDefinition, out TEntityDefinitionBuilder, out TMqttEntityConfiguration>
        : IMqttEntityConfigurationBuilder<TSelf, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
            where TSelf : IMqttStatefulEntityConfigurationBuilder<TSelf, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
            where TEntityDefinitionBuilder : class, IStatefulEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    {
        TSelf WithStateMessageQualityOfServiceLevel(MqttQualityOfServiceLevel? qualityOfServiceLevel);
        TSelf WithRetainedStateMessages(bool retainStateMessages = true);

        TSelf WithDefaultStateChangeHandlers();
        TSelf WithStateChangeHandler(
            Func<TEntityDefinition, TEntity, string> stateMessagePayloadSelector,
            Func<TEntity, IObservable<Unit>> stateChangeDetectionSelector
        );
        TSelf WithStateChangeHandler(IStateChangeHandler<TEntity, TEntityDefinition> stateChangeHandler);
    }
}
