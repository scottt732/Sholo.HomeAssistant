using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class ButtonMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<ButtonMqttEntityConfigurationBuilder, IButtonMqttEntityConfigurationBuilder, IButton, IButtonEntityDefinition, ButtonEntityDefinitionBuilder, IButtonMqttEntityConfiguration>,
    IButtonMqttEntityConfigurationBuilder
{
    public override IButtonMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => WithCommandHandler(new ButtonCommandHandler());

    public override IButtonMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => WithStateChangeHandler(new ButtonStateChangeHandler());

    protected override IButtonMqttEntityConfiguration Build(
        IButton entity,
        IButtonEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IButton, IButtonEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<IButton, IButtonEntityDefinition>[] stateChangeHandlers)
        => new ButtonMqttEntityConfiguration(
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

    public ButtonMqttEntityConfigurationBuilder()
        : base("button")
    {
    }
}
