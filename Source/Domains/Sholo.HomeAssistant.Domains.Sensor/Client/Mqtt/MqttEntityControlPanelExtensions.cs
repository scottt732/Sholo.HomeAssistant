using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition> Sensors(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>(DomainRegistry.Instance.Sensor());

    public static IMqttEntityControlPanel AddSensor(this IMqttEntityControlPanel controlPanel, ISensorMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>(DomainRegistry.Instance.Sensor(), configuration);
        return controlPanel;
    }
}
