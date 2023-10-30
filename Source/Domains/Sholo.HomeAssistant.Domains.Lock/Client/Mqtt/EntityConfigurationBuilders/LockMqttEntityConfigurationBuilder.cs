using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class LockMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<LockMqttEntityConfigurationBuilder, ILockMqttEntityConfigurationBuilder, ILock, ILockEntityDefinition, LockEntityDefinitionBuilder, ILockMqttEntityConfiguration>,
    ILockMqttEntityConfigurationBuilder
{
    public override ILockMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => WithStateChangeHandler(new LockStateChangeHandler());

    public override ILockMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => WithCommandHandler(new LockCommandHandler());

    protected override ILockMqttEntityConfiguration Build(
        ILock entity,
        ILockEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<ILock, ILockEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<ILock, ILockEntityDefinition>[] stateChangeHandlers
    )
        => new LockMqttEntityConfiguration(
            entity,
            entityDefinition,
            discoveryTopic,
            discoveryMessage,
            deleteMessage,
            discoveryMessageQualityOfServiceLevel,
            retainDiscoveryMessage,
            commandHandlers,
            stateMessageQualityOfServiceLevel,
            retainStateMessages,
            stateChangeHandlers
        );

    public LockMqttEntityConfigurationBuilder()
        : base("lock")
    {
    }
}
