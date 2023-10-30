using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class BinarySensorMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<BinarySensorMqttEntityConfigurationBuilder, IBinarySensorMqttEntityConfigurationBuilder, IBinarySensor, IBinarySensorEntityDefinition, BinarySensorEntityDefinitionBuilder, IBinarySensorMqttEntityConfiguration>,
    IBinarySensorMqttEntityConfigurationBuilder
{
    public override IBinarySensorMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => WithStateChangeHandler(new BinarySensorStateChangeHandler());

    public override IBinarySensorMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override IBinarySensorMqttEntityConfiguration Build(
        IBinarySensor entity,
        IBinarySensorEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IBinarySensor, IBinarySensorEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<IBinarySensor, IBinarySensorEntityDefinition>[] stateChangeHandlers
    )
        => new BinarySensorMqttEntityConfiguration(
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

    public BinarySensorMqttEntityConfigurationBuilder()
        : base("binary_sensor")
    {
    }
}
