using Sholo.HomeAssistant.Mqtt.Entities.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Vacuum;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Vacuum
{
    public interface IVacuumMqttEntityConfigurationBuilder
        : IMqttStatefulEntityConfigurationBuilder<IVacuumMqttEntityConfigurationBuilder, IVacuum, IVacuumEntityDefinition, VacuumEntityDefinitionBuilder, IVacuumMqttEntityConfiguration>
    {
    }
}
