using System;
using System.Linq;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

[PublicAPI]
public abstract class BaseStatelessMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    : BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>,
        IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TSelf : BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>, TSelfInterface
    where TSelfInterface : IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
    where TEntityDefinitionBuilder : class, IEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
{
    public override TMqttEntityConfiguration Build()
        => Build(
            Entity ?? throw new InvalidOperationException("You must set the entity"),
            EntityDefinition ?? throw new InvalidOperationException("You must set the entity definition"),
            DiscoveryTopic ?? throw new InvalidOperationException("You must set the discovery topic"),
            DiscoveryMessage ?? CreateDefaultDiscoveryMessage(EntityDefinition),
            DeleteMessage ?? CreateDefaultDeleteMessage(),
            DiscoveryMessageQualityOfServiceLevel,
            RetainDiscoveryMessages ?? true,
            CommandHandlers.ToArray()
        );

    protected abstract TMqttEntityConfiguration Build(
        TEntity entity,
        TEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<TEntity, TEntityDefinition>[] commandHandlers
    );

    protected BaseStatelessMqttEntityConfigurationBuilder(string componentType)
        : base(componentType)
    {
    }
}
