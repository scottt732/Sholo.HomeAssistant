using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class MqttEntityControlPanelExtensions
{
    public static IEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition> Locks(this IMqttEntityControlPanel controlPanel)
        => controlPanel.StatefulEntitiesOfType<LockDomain, ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

    public static IMqttEntityControlPanel AddLock(this IMqttEntityControlPanel controlPanel, ILockMqttEntityConfiguration configuration)
    {
        controlPanel.AddStatefulEntity<LockDomain, ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>(configuration);
        return controlPanel;
    }
}
