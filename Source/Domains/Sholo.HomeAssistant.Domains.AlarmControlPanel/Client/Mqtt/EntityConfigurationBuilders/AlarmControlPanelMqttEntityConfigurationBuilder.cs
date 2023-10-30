using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class AlarmControlPanelMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<AlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanel, IAlarmControlPanelEntityDefinition, AlarmControlPanelEntityDefinitionBuilder, IAlarmControlPanelMqttEntityConfiguration>,
    IAlarmControlPanelMqttEntityConfigurationBuilder
{
    public override IAlarmControlPanelMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => this;

    public override IAlarmControlPanelMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override IAlarmControlPanelMqttEntityConfiguration Build(
        IAlarmControlPanel entity,
        IAlarmControlPanelEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IAlarmControlPanel, IAlarmControlPanelEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<IAlarmControlPanel, IAlarmControlPanelEntityDefinition>[] stateChangeHandlers
    )
        => new AlarmControlPanelMqttEntityConfiguration(
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

    public AlarmControlPanelMqttEntityConfigurationBuilder()
        : base("alarm_control_panel")
    {
    }
}
