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
        => controlPanel.EntitiesOfType<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(DomainRegistry.Instance.Climate()); // TODO: Not stateful?!

    public static IMqttEntityControlPanel AddClimate(this IMqttEntityControlPanel controlPanel, IClimateMqttEntityConfiguration configuration)
    {
        controlPanel.AddEntity<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(DomainRegistry.Instance.Climate(), configuration); // TODO: Not stateful?!
        return controlPanel;
    }
}
