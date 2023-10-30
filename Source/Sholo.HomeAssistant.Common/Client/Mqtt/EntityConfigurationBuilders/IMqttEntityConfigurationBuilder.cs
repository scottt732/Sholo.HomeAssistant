using System;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.DiscoveryTopics;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

[PublicAPI]
public interface IMqttEntityConfigurationBuilder<out TSelf, TEntity, TEntityDefinition, out TEntityDefinitionBuilder, out TMqttEntityConfiguration>
    where TSelf : IMqttEntityConfigurationBuilder<TSelf, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
    where TEntityDefinitionBuilder : class, IEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
{
    TSelf WithEntity(TEntity entity);
    TSelf WithEntityDefinition(TEntityDefinition entityDefinition);
    TSelf WithEntityDefinition(Action<TEntityDefinitionBuilder> configurator);
    TSelf WithDiscoveryTopic(string discoveryTopic);
    TSelf WithDiscoveryTopic(Action<IDiscoveryTopicBuilder> configurator);

    TSelf WithDiscoveryMessageQualityOfServiceLevel(QualityOfServiceLevel qualityOfServiceLevel);
    TSelf WithRetainedDiscoveryMessages(bool retain = true);
    TSelf WithDiscoveryMessage(IApplicationMessage discoveryMessage);
    TSelf WithDiscoveryMessage(Action<IApplicationMessageBuilder> configurator);
    TSelf WithDeleteMessage(IApplicationMessage deleteMessage);
    TSelf WithDeleteMessage(Action<IApplicationMessageBuilder> configurator);

    TSelf WithDefaultCommandHandlers();
    TSelf WithCommandHandler(
        Func<TEntityDefinition, string> topicPatternSelector,
        Func<ICommandContext<TEntity, TEntityDefinition>, string, Task<bool>> commandProcessor
    );
    TSelf WithCommandHandler(ICommandHandler<TEntity, TEntityDefinition> commandHandler);

    TMqttEntityConfiguration Build();
}
