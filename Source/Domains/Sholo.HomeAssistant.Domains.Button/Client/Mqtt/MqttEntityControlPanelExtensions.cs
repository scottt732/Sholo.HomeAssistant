using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IButtonMqttEntityConfiguration, IButton, IButtonEntityDefinition> Buttons(this IMqttEntityControlPanel controlPanel)
        => controlPanel.EntitiesOfType<ButtonDomain, IButtonMqttEntityConfiguration, IButton, IButtonEntityDefinition>();

    public static IMqttEntityControlPanel AddButton(this IMqttEntityControlPanel controlPanel, IButtonMqttEntityConfiguration configuration)
    {
        controlPanel.AddEntity<ButtonDomain, IButtonMqttEntityConfiguration, IButton, IButtonEntityDefinition>(configuration);
        return controlPanel;
    }
}
