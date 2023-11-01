using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition> Lights(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<LightDomain, ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

    public static IMqttEntityControlPanel AddLight(this IMqttEntityControlPanel controlPanel, ILightMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<LightDomain, ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>(configuration);
        return controlPanel;
    }
}
