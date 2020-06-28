using Sholo.HomeAssistant.Mqtt.Entities.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Vacuum
{
    public interface IVacuumMqttEntityConfiguration : IMqttStatefulEntityConfiguration<IVacuum, IVacuumEntityDefinition>
    {
    }
}
