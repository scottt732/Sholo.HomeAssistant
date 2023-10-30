using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition> Covers(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>(DomainRegistry.Instance.Cover());

    public static IMqttEntityControlPanel AddCover(this IMqttEntityControlPanel controlPanel, ICoverMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>(DomainRegistry.Instance.Cover(), configuration);
        return controlPanel;
    }
}
