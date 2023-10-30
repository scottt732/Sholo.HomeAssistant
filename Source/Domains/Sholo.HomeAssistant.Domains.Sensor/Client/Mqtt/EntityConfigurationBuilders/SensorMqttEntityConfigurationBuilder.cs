using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class SensorMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<SensorMqttEntityConfigurationBuilder, ISensorMqttEntityConfigurationBuilder, ISensor, ISensorEntityDefinition, SensorEntityDefinitionBuilder, ISensorMqttEntityConfiguration>,
    ISensorMqttEntityConfigurationBuilder
{
    public override ISensorMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => WithStateChangeHandler(new SensorValuesStateChangeHandler());

    public override ISensorMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override ISensorMqttEntityConfiguration Build(
        ISensor entity,
        ISensorEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<ISensor, ISensorEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<ISensor, ISensorEntityDefinition>[] stateChangeHandlers
    )
        => new SensorMqttEntityConfiguration(
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
            stateChangeHandlers);

    public SensorMqttEntityConfigurationBuilder()
        : base("sensor")
    {
    }
}
