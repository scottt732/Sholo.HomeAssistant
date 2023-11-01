using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition> Sensors(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<SensorDomain, ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

    public static IMqttEntityControlPanel AddSensor(this IMqttEntityControlPanel controlPanel, ISensorMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<SensorDomain, ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>(configuration);
        return controlPanel;
    }
}
