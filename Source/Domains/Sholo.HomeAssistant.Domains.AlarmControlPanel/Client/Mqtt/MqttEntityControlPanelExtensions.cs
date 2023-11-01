using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition> AlarmControlPanels(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<AlarmControlPanelDomain, IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

    public static IMqttEntityControlPanel AddAlarmControlPanel(this IMqttEntityControlPanel controlPanel, IAlarmControlPanelMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<AlarmControlPanelDomain, IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>(configuration);
        return controlPanel;
    }
}
