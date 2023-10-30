using System;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public abstract class BaseMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    : BaseMqttEntityConfiguration<TEntity, TEntityDefinition>, IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    public QualityOfServiceLevel? StateMessageQualityOfServiceLevel { get; }
    public bool RetainStateMessages { get; }
    public IStateChangeHandler<TEntity, TEntityDefinition>[] StateChangeHandlers { get; }

    protected BaseMqttStatefulEntityConfiguration(
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
