using Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.AlarmControlPanel
{
    public interface IAlarmControlPanelMqttEntityConfiguration : IMqttStatefulEntityConfiguration<IAlarmControlPanel, IAlarmControlPanelEntityDefinition>
    {
    }
}
