using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.DiscoveryTopics;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

[PublicAPI]
public abstract class BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    : IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TSelf : BaseMqttEntityConfigurationBuilder<TSelf, TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>, TSelfInterface
    where TSelfInterface : IMqttEntityConfigurationBuilder<TSelfInterface, TEntity, TEntityDefinition, TEntityDefinitionBuilder, TMqttEntityConfiguration>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
    where TEntityDefinitionBuilder : class, IEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>, new()
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
{
    protected TEntity? Entity { get; private set; }
    protected TEntityDefinition? EntityDefinition { get; private set; }
    protected string? DiscoveryTopic { get; private set; }
    protected bool? RetainDiscoveryMessages { get; private set; }
    protected QualityOfServiceLevel? DiscoveryMessageQualityOfServiceLevel { get; private set; }
    protected IApplicationMessage? DiscoveryMessage { get; private set; }
    protected IApplicationMessage? DeleteMessage { get; private set; }
    protected Collection<ICommandHandler<TEntity, TEntityDefinition>> CommandHandlers { get; } = new();

    protected string ComponentType { get; }
    protected JsonSerializer JsonSerializer { get; } = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);

    protected BaseMqttEntityConfigurationBuilder(string componentType)
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
        Func<ICommandContext<TEntity, TEntityDefinition>, string, Task<bool>> commandProcessor)
    {
        CommandHandlers.Add(new DelegateCommandHandler<TEntity, TEntityDefinition>(topicPatternSelector, commandProcessor));
        return (TSelf)this;
    }

    public TSelfInterface WithCommandHandler(ICommandHandler<TEntity, TEntityDefinition> commandHandler)
    {
        CommandHandlers.Add(commandHandler);
        return (TSelf)this;
    }

    public TSelfInterface WithDiscoveryMessageQualityOfServiceLevel(QualityOfServiceLevel qualityOfServiceLevel)
    {
        DiscoveryMessageQualityOfServiceLevel = qualityOfServiceLevel;
        return (TSelf)this;
    }

    public TSelfInterface WithRetainedDiscoveryMessages(bool retain = true)
    {
        RetainDiscoveryMessages = retain;
        return (TSelf)this;
    }

    public TSelfInterface WithDiscoveryMessage(IApplicationMessage discoveryMessage)
    {
        DiscoveryMessage = discoveryMessage;
        return (TSelf)this;
    }

    public TSelfInterface WithDiscoveryMessage(Action<IApplicationMessageBuilder> configurator)
    {
        var messageBuilder = new ApplicationMessageBuilder();
        configurator.Invoke(messageBuilder);
        DiscoveryMessage = messageBuilder.Build();
        return (TSelf)this;
    }

    public TSelfInterface WithDeleteMessage(IApplicationMessage deleteMessage)
    {
        DeleteMessage = deleteMessage;
        return (TSelf)this;
    }

    public TSelfInterface WithDeleteMessage(Action<IApplicationMessageBuilder> configurator)
    {
        var messageBuilder = new ApplicationMessageBuilder();
        configurator.Invoke(messageBuilder);
        DeleteMessage = messageBuilder.Build();
        return (TSelf)this;
    }

    public abstract TMqttEntityConfiguration Build();

    protected IApplicationMessage CreateDefaultDiscoveryMessage(TEntityDefinition entityDefinition)
    {
        var messageBuilder = new ApplicationMessageBuilder()
            .WithTopic(DiscoveryTopic)
            .WithPayload(GetDiscoveryPayloadString(entityDefinition))
            .WithRetainFlag(RetainDiscoveryMessages);

        if (DiscoveryMessageQualityOfServiceLevel.HasValue)
        {
            messageBuilder = messageBuilder.WithQualityOfServiceLevel(DiscoveryMessageQualityOfServiceLevel.Value);
        }

        return messageBuilder.Build();
    }

    protected IApplicationMessage CreateDefaultDeleteMessage()
    {
        var messageBuilder = new ApplicationMessageBuilder()
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
        using var sw = new StringWriter(sb);

        JsonSerializer.Serialize(sw, entityDefinition);
        return sb.ToString();
    }
}
