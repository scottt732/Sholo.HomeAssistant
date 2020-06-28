using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Camera
{
    public class CameraMqttEntityConfiguration : BaseMqttEntityConfiguration<ICamera, ICameraEntityDefinition>, ICameraMqttEntityConfiguration
    {
        public CameraMqttEntityConfiguration(
            ICamera entity,
            ICameraEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessages,
            ICommandHandler<ICamera, ICameraEntityDefinition>[] commandHandlers
        )
            : base(
                entity,
                entityDefinition,
                discoveryTopic,
                discoveryMessage,
                deleteMessage,
                discoveryMessageQualityOfServiceLevel,
                retainDiscoveryMessages,
                commandHandlers
            )
        {
        }
    }
}
