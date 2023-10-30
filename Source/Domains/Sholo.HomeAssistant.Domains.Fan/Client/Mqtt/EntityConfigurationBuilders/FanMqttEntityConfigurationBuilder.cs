using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class FanMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<FanMqttEntityConfigurationBuilder, IFanMqttEntityConfigurationBuilder, IFan, IFanEntityDefinition, FanEntityDefinitionBuilder, IFanMqttEntityConfiguration>,
    IFanMqttEntityConfigurationBuilder
{
    public override IFanMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => this;

    public override IFanMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override IFanMqttEntityConfiguration Build(
        IFan entity,
        IFanEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IFan, IFanEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<IFan, IFanEntityDefinition>[] stateChangeHandlers
    )
        => new FanMqttEntityConfiguration(
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

    public FanMqttEntityConfigurationBuilder()
        : base("fan")
    {
    }
}
