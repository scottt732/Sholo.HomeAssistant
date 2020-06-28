using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock
{
    public interface ILockMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ILock, ILockEntityDefinition>
    {
    }
}
