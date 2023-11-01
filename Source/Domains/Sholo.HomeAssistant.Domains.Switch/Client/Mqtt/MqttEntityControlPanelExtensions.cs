using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition> Switches(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<SwitchDomain, ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

    public static IMqttEntityControlPanel AddSwitch(this IMqttEntityControlPanel controlPanel, ISwitchMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<SwitchDomain, ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>(configuration);
        return controlPanel;
    }
}
