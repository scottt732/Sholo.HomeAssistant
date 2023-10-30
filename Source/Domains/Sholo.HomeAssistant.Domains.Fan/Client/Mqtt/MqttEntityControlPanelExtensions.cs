using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition> Fans(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>(DomainRegistry.Instance.Fan());

    public static IMqttEntityControlPanel AddFan(this IMqttEntityControlPanel controlPanel, IFanMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>(DomainRegistry.Instance.Fan(), configuration);
        return controlPanel;
    }
}
