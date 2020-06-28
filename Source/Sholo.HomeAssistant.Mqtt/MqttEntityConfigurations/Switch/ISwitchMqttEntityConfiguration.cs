using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch
{
    public interface ISwitchMqttEntityConfiguration : IMqttStatefulEntityConfiguration<ISwitch, ISwitchEntityDefinition>
    {
    }
}
