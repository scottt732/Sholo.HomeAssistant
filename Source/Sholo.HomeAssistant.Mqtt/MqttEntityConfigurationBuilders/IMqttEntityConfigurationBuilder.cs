using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Discovery.Topics;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders
{
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

        TSelf WithDiscoveryMessageQualityOfServiceLevel(MqttQualityOfServiceLevel qualityOfServiceLevel);
        TSelf WithRetainedDiscoveryMessages(bool retain = true);
        TSelf WithDiscoveryMessage(MqttApplicationMessage discoveryMessage);
        TSelf WithDiscoveryMessage(Action<MqttApplicationMessageBuilder> configurator);
        TSelf WithDeleteMessage(MqttApplicationMessage deleteMessage);
        TSelf WithDeleteMessage(Action<MqttApplicationMessageBuilder> configurator);

        TSelf WithDefaultCommandHandlers();
        TSelf WithCommandHandler(
            Func<TEntityDefinition, string> topicPatternSelector,
            Func<MqttCommandContext<TEntity, TEntityDefinition>, string, Task<bool>> commandProcessor
        );
        TSelf WithCommandHandler(ICommandHandler<TEntity, TEntityDefinition> commandHandler);

        TMqttEntityConfiguration Build();
    }
}
