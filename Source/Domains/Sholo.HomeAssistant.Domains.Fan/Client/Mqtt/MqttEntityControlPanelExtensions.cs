using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition> Fans(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<FanDomain, IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

    public static IMqttEntityControlPanel AddFan(this IMqttEntityControlPanel controlPanel, IFanMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<FanDomain, IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>(configuration);
        return controlPanel;
    }
}
