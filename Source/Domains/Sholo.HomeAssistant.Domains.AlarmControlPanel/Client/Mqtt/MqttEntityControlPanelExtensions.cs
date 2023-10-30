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
        => controlPanel.StatefulEntitiesOfType<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>(DomainRegistry.Instance.AlarmControlPanel());

    public static IMqttEntityControlPanel AddAlarmControlPanel(this IMqttEntityControlPanel controlPanel, IAlarmControlPanelMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>(DomainRegistry.Instance.AlarmControlPanel(), configuration);
        return controlPanel;
    }
}
