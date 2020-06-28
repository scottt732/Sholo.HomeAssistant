using Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.DeviceTrigger
{
    public interface IDeviceTriggerMqttEntityConfiguration : IMqttEntityConfiguration<IDeviceTrigger, IDeviceTriggerEntityDefinition>
    {
    }
}