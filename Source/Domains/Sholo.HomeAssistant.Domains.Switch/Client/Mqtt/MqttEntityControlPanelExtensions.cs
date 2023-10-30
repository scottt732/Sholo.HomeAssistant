using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition> Switches(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>(DomainRegistry.Instance.Switch());

    public static IMqttEntityControlPanel AddSwitch(this IMqttEntityControlPanel controlPanel, ISwitchMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>(DomainRegistry.Instance.Switch(), configuration);
        return controlPanel;
    }
}
