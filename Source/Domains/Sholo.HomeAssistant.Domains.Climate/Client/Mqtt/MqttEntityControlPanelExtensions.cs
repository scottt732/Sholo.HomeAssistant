using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition> Climate(this IMqttEntityControlPanel controlPanel)
        => controlPanel.EntitiesOfType<ClimateDomain, IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(); // TODO: Not stateful?!

    public static IMqttEntityControlPanel AddClimate(this IMqttEntityControlPanel controlPanel, IClimateMqttEntityConfiguration configuration)
    {
        controlPanel.AddEntity<ClimateDomain, IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(configuration); // TODO: Not stateful?!
        return controlPanel;
    }
}
