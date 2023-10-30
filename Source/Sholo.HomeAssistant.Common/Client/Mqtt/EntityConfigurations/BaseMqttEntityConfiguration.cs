using System;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public abstract class BaseMqttEntityConfiguration<TEntity, TEntityDefinition> : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public TEntity Entity { get; }
    public TEntityDefinition EntityDefinition { get; }
    public string DiscoveryTopic { get; }
    public IApplicationMessage DiscoveryMessage { get; }
    public IApplicationMessage DeleteMessage { get; }
    public QualityOfServiceLevel? DiscoveryMessageQualityOfServiceLevel { get; }
    public bool RetainDiscoveryMessage { get; }

    public ICommandHandler<TEntity, TEntityDefinition>[] CommandHandlers { get; }

    protected BaseMqttEntityConfiguration(
        TEntity entity,
        TEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
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
