using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition> Vacuums(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<VacuumDomain, IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

    public static IMqttEntityControlPanel AddVacuum(this IMqttEntityControlPanel controlPanel, IVacuumMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<VacuumDomain, IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>(configuration);
        return controlPanel;
    }
}
