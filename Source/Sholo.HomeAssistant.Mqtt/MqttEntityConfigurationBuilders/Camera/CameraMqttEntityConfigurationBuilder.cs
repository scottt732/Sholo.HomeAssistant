using System.Linq;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Camera;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Camera
{
    public class CameraMqttEntityConfigurationBuilder :
        BaseMqttEntityConfigurationBuilder<CameraMqttEntityConfigurationBuilder, ICameraMqttEntityConfigurationBuilder, ICamera, ICameraEntityDefinition, CameraEntityDefinitionBuilder, ICameraMqttEntityConfiguration>,
        ICameraMqttEntityConfigurationBuilder
    {
        public override ICameraMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        public override ICameraMqttEntityConfiguration Build()
            => Build(
                Entity,
                EntityDefinition,
                DiscoveryTopic,
                DiscoveryMessage,
                DeleteMessage,
                DiscoveryMessageQualityOfServiceLevel,
                RetainDiscoveryMessages,
                CommandHandlers.ToArray()
            );

        private ICameraMqttEntityConfiguration Build(
            ICamera entity,
            ICameraEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessages,
            ICommandHandler<ICamera, ICameraEntityDefinition>[] commandHandlers)
            => new CameraMqttEntityConfiguration(
                entity,
                entityDefinition,
                discoveryTopic,
                discoveryMessage,
                deleteMessage,
                discoveryMessageQualityOfServiceLevel,
                retainDiscoveryMessages,
                commandHandlers
            );

        public CameraMqttEntityConfigurationBuilder()
            : base(ComponentType.Camera)
        {
        }
    }
}
