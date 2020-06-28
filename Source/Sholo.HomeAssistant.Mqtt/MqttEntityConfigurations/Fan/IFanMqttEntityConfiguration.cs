using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Fan
{
    public interface IFanMqttEntityConfiguration : IMqttStatefulEntityConfiguration<IFan, IFanEntityDefinition>
    {
    }
}
