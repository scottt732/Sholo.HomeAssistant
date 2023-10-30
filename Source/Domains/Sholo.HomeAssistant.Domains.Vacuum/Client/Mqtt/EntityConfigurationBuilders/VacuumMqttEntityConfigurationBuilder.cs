using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class VacuumMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<VacuumMqttEntityConfigurationBuilder, IVacuumMqttEntityConfigurationBuilder, IVacuum, IVacuumEntityDefinition, VacuumEntityDefinitionBuilder, IVacuumMqttEntityConfiguration>,
    IVacuumMqttEntityConfigurationBuilder
{
    public override IVacuumMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => this;

    public override IVacuumMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override IVacuumMqttEntityConfiguration Build(
        IVacuum entity,
        IVacuumEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IVacuum, IVacuumEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<IVacuum, IVacuumEntityDefinition>[] stateChangeHandlers)
        => new VacuumMqttEntityConfiguration(
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

    public VacuumMqttEntityConfigurationBuilder()
        : base("vacuum")
    {
    }
}
