using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.BinarySensor
{
    public interface IBinarySensorMqttEntityConfiguration : IMqttStatefulEntityConfiguration<IBinarySensor, IBinarySensorEntityDefinition>
    {
    }
}
