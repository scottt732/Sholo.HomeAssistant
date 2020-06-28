using Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.DeviceTrigger;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.DeviceTrigger
{
    public interface IDeviceTriggerMqttEntityConfigurationBuilder
        : IMqttEntityConfigurationBuilder<IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTrigger, IDeviceTriggerEntityDefinition, DeviceTriggerEntityDefinitionBuilder, IDeviceTriggerMqttEntityConfiguration>
    {
    }
}
