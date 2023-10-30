using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public class AlarmControlPanelMqttEntityConfiguration : BaseMqttStatefulEntityConfiguration<IAlarmControlPanel, IAlarmControlPanelEntityDefinition>, IAlarmControlPanelMqttEntityConfiguration
{
    public AlarmControlPanelMqttEntityConfiguration(
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
        : base(
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
        )
    {
    }
}
