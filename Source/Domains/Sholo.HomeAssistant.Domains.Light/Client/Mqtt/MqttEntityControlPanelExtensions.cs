using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition> Lights(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>(DomainRegistry.Instance.Light());

    public static IMqttEntityControlPanel AddLight(this IMqttEntityControlPanel controlPanel, ILightMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>(DomainRegistry.Instance.Light(), configuration);
        return controlPanel;
    }
}
