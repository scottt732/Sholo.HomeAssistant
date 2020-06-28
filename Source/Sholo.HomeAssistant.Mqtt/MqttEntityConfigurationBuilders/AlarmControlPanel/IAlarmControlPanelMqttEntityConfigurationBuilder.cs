using Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.AlarmControlPanel;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.AlarmControlPanel
{
    public interface IAlarmControlPanelMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<IAlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanel, IAlarmControlPanelEntityDefinition, AlarmControlPanelEntityDefinitionBuilder, IAlarmControlPanelMqttEntityConfiguration>
    {
    }
}
