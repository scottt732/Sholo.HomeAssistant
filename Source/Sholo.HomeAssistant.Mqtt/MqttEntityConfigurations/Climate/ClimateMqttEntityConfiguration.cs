using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Climate;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Climate;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Climate
{
    public class ClimateMqttEntityConfiguration : BaseMqttEntityConfiguration<IClimate, IClimateEntityDefinition>, IClimateMqttEntityConfiguration
    {
        public ClimateMqttEntityConfiguration(
            IClimate entity,
            IClimateEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<IClimate, IClimateEntityDefinition>[] commandHandlers
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
