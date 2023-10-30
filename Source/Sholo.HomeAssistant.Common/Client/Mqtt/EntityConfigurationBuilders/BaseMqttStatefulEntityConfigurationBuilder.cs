using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public abstract class BaseMqttStatefulEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    : BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>,
        IMqttStatefulEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
            where TSelf : BaseMqttStatefulEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>, TSelfInterface
            where TSelfInterface : IMqttStatefulEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>, IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
            where TEntityDefinitionBuilder : class, IStatefulEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
{
    private QualityOfServiceLevel? StateMessageQualityOfServiceLevel { get; set; }
    private bool? RetainStateMessages { get; set; }

    private List<IStateChangeHandler<TEntity, TEntityDefinition>> StateChangeHandlers { get; } = new();

    public TSelfInterface WithStateMessageQualityOfServiceLevel(QualityOfServiceLevel? qualityOfServiceLevel)
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
            RetainDiscoveryMessages ?? true,
            CommandHandlers.ToArray(),
            StateMessageQualityOfServiceLevel,
            RetainStateMessages ?? false,
            StateChangeHandlers.ToArray()
        );

    protected abstract TMqttEntityConfiguration Build(
        TEntity entity,
        TEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<TEntity, TEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<TEntity, TEntityDefinition>[] stateChangeHandlers
    );

    protected BaseMqttStatefulEntityConfigurationBuilder(string componentType)
        : base(componentType)
    {
    }
}
