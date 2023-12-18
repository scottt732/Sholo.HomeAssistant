using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

[PublicAPI]
public class SwitchMqttEntityConfigurationBuilder
    : BaseMqttStatefulEntityConfigurationBuilder<SwitchMqttEntityConfigurationBuilder, ISwitchMqttEntityConfigurationBuilder, ISwitch, ISwitchEntityDefinition, SwitchEntityDefinitionBuilder, ISwitchMqttEntityConfiguration>,
        ISwitchMqttEntityConfigurationBuilder
{
    public override ISwitchMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => WithStateChangeHandler(new SwitchStateChangeHandler());

    public override ISwitchMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => WithCommandHandler(new SwitchCommandHandler());

    protected override ISwitchMqttEntityConfiguration Build(
        ISwitch entity,
        ISwitchEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<ISwitch, ISwitchEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<ISwitch, ISwitchEntityDefinition>[] stateChangeHandlers
    )
        => new SwitchMqttEntityConfiguration(
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

    public SwitchMqttEntityConfigurationBuilder()
        : base("switch")
    {
    }
}
