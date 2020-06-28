using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Protocol;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Discovery.Topics;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders
{
    public abstract class BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
        : IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
            where TSelf : BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>, TSelfInterface
            where TSelfInterface : IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
            where TEntityDefinitionBuilder : class, IEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    {
        protected TEntity Entity { get; set; }
        protected TEntityDefinition EntityDefinition { get; set; }
        protected string DiscoveryTopic { get; set; }
        protected bool RetainDiscoveryMessages { get; set; }
        protected MqttQualityOfServiceLevel? DiscoveryMessageQualityOfServiceLevel { get; set; }
        protected MqttApplicationMessage DiscoveryMessage { get; set; }
        protected MqttApplicationMessage DeleteMessage { get; set; }

        protected List<ICommandHandler<TEntity, TEntityDefinition>> CommandHandlers { get; } = new List<ICommandHandler<TEntity, TEntityDefinition>>();

        protected ComponentType ComponentType { get; }

        protected JsonSerializer JsonSerializer { get; } = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);

        protected BaseMqttEntityConfigurationBuilder(ComponentType componentType)
        {
            ComponentType = componentType;
        }

        public TSelfInterface WithEntity(TEntity entity)
        {
            Entity = entity;
            return (TSelf)this;
        }

        public TSelfInterface WithEntityDefinition(TEntityDefinition entityDefinition)
        {
            EntityDefinition = entityDefinition;
            return (TSelf)this;
        }

        public TSelfInterface WithEntityDefinition(Action<TEntityDefinitionBuilder> configurator)
        {
            var builder = new TEntityDefinitionBuilder();
            configurator.Invoke(builder);
            EntityDefinition = builder.Build();
            return (TSelf)this;
        }

        public TSelfInterface WithDiscoveryTopic(string discoveryTopic)
        {
            DiscoveryTopic = discoveryTopic;
            return (TSelf)this;
        }

        public TSelfInterface WithDiscoveryTopic(Action<IDiscoveryTopicBuilder> configurator)
        {
            var builder = new DiscoveryTopicBuilder(ComponentType);
            configurator.Invoke(builder);
            DiscoveryTopic = builder.Build();
            return (TSelf)this;
        }

        public abstract TSelfInterface WithDefaultCommandHandlers();

        public TSelfInterface WithCommandHandler(
            Func<TEntityDefinition, string> topicPatternSelector,
            Func<MqttCommandContext<TEntity, TEntityDefinition>, string, Task<bool>> commandProcessor)
        {
            CommandHandlers.Add(new DelegateCommandHandler<TEntity, TEntityDefinition>(topicPatternSelector, commandProcessor));
            return (TSelf)this;
        }

        public TSelfInterface WithCommandHandler(ICommandHandler<TEntity, TEntityDefinition> commandHandler)
        {
            CommandHandlers.Add(commandHandler);
            return (TSelf)this;
        }

        public TSelfInterface WithDiscoveryMessageQualityOfServiceLevel(MqttQualityOfServiceLevel qualityOfServiceLevel)
        {
            DiscoveryMessageQualityOfServiceLevel = qualityOfServiceLevel;
            return (TSelf)this;
        }

        public TSelfInterface WithRetainedDiscoveryMessages(bool retain = true)
        {
            RetainDiscoveryMessages = retain;
            return (TSelf)this;
        }

        public TSelfInterface WithDiscoveryMessage(MqttApplicationMessage discoveryMessage)
        {
            DiscoveryMessage = discoveryMessage;
            return (TSelf)this;
        }

        public TSelfInterface WithDiscoveryMessage(Action<MqttApplicationMessageBuilder> configurator)
        {
            var messageBuilder = new MqttApplicationMessageBuilder();
            configurator.Invoke(messageBuilder);
            DiscoveryMessage = messageBuilder.Build();
            return (TSelf)this;
        }

        public TSelfInterface WithDeleteMessage(MqttApplicationMessage deleteMessage)
        {
            DeleteMessage = deleteMessage;
            return (TSelf)this;
        }

        public TSelfInterface WithDeleteMessage(Action<MqttApplicationMessageBuilder> configurator)
        {
            var messageBuilder = new MqttApplicationMessageBuilder();
            configurator.Invoke(messageBuilder);
            DeleteMessage = messageBuilder.Build();
            return (TSelf)this;
        }

        public abstract TMqttEntityConfiguration Build();

        protected MqttApplicationMessage CreateDefaultDiscoveryMessage(TEntityDefinition entityDefinition)
        {
            var messageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic(DiscoveryTopic)
                .WithPayload(GetDiscoveryPayloadString(entityDefinition))
                .WithRetainFlag(RetainDiscoveryMessages);

            if (DiscoveryMessageQualityOfServiceLevel.HasValue)
            {
                messageBuilder = messageBuilder.WithQualityOfServiceLevel(DiscoveryMessageQualityOfServiceLevel.Value);
            }

            return messageBuilder.Build();
        }

        protected MqttApplicationMessage CreateDefaultDeleteMessage()
        {
            var messageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic(DiscoveryTopic)
                .WithPayload(Array.Empty<byte>());

            if (DiscoveryMessageQualityOfServiceLevel.HasValue)
            {
                messageBuilder = messageBuilder.WithQualityOfServiceLevel(DiscoveryMessageQualityOfServiceLevel.Value);
            }

            var message = messageBuilder.Build();
            return message;
        }

        private string GetDiscoveryPayloadString(TEntityDefinition entityDefinition)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                JsonSerializer.Serialize(sw, entityDefinition);
                return sb.ToString();
            }
        }
    }
}
