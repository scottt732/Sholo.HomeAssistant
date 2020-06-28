using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.AlarmControlPanel
{
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
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<IAlarmControlPanel, IAlarmControlPanelEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
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
            : base(ComponentType.AlarmControlPanel)
        {
        }
    }
}
