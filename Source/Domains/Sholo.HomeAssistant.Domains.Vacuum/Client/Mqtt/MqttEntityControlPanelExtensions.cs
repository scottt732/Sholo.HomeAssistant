using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition> Vacuums(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>(DomainRegistry.Instance.Vacuum());

    public static IMqttEntityControlPanel AddVacuum(this IMqttEntityControlPanel controlPanel, IVacuumMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>(DomainRegistry.Instance.Vacuum(), configuration);
        return controlPanel;
    }
}
