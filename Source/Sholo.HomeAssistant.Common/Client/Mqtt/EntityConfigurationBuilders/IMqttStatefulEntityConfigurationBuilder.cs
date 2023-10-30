using System;
using System.Reactive;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

[PublicAPI]
public interface IMqttStatefulEntityConfigurationBuilder<out TSelf, TEntity, TEntityDefinition, out TEntityDefinitionBuilder, out TMqttEntityConfiguration>
    : IMqttEntityConfigurationBuilder<TSelf, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TSelf : IMqttStatefulEntityConfigurationBuilder<TSelf, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
    where TEntityDefinitionBuilder : class, IStatefulEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
    where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
{
    TSelf WithStateMessageQualityOfServiceLevel(QualityOfServiceLevel? qualityOfServiceLevel);
    TSelf WithRetainedStateMessages(bool retainStateMessages = true);

    TSelf WithDefaultStateChangeHandlers();
    TSelf WithStateChangeHandler(
        Func<TEntityDefinition, TEntity, string> stateMessagePayloadSelector,
        Func<TEntity, IObservable<Unit>> stateChangeDetectionSelector
    );
    TSelf WithStateChangeHandler(IStateChangeHandler<TEntity, TEntityDefinition> stateChangeHandler);
}
