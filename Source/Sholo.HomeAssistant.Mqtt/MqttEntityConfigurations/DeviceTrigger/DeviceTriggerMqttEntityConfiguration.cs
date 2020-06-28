using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.DeviceTrigger
{
    public class DeviceTriggerMqttEntityConfiguration : BaseMqttEntityConfiguration<IDeviceTrigger, IDeviceTriggerEntityDefinition>, IDeviceTriggerMqttEntityConfiguration
    {
        public DeviceTriggerMqttEntityConfiguration(
            IDeviceTrigger entity,
            IDeviceTriggerEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<IDeviceTrigger, IDeviceTriggerEntityDefinition>[] commandHandlers
        )
            : base(
                entity,
                entityDefinition,
                discoveryTopic,
                discoveryMessage,
                deleteMessage,
                discoveryMessageQualityOfServiceLevel,
                retainDiscoveryMessage,
                commandHandlers
            )
        {
        }
    }
}
