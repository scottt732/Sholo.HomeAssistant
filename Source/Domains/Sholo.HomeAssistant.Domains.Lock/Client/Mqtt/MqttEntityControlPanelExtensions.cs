using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition> Locks(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>(DomainRegistry.Instance.Lock());

    public static IMqttEntityControlPanel AddLock(this IMqttEntityControlPanel controlPanel, ILockMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>(DomainRegistry.Instance.Lock(), configuration);
        return controlPanel;
    }
}
