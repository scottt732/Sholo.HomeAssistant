using Sholo.HomeAssistant.Mqtt.Entities.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Light
{
    public interface ILightMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ILight, ILightEntityDefinition>
    {
    }
}
