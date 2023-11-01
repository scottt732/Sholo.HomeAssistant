using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition> BinarySensors(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<BinarySensorDomain, IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

    public static IMqttEntityControlPanel AddBinarySensor(this IMqttEntityControlPanel controlPanel, IBinarySensorMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<BinarySensorDomain, IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>(configuration);
        return controlPanel;
    }
}
