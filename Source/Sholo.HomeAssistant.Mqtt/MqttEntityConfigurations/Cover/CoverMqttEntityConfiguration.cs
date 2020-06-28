using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Cover
{
    public class CoverMqttEntityConfiguration : BaseMqttStatefulEntityConfiguration<ICover, ICoverEntityDefinition>, ICoverMqttEntityConfiguration
    {
        public CoverMqttEntityConfiguration(
            ICover entity,
            ICoverEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<ICover, ICoverEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<ICover, ICoverEntityDefinition>[] stateChangeHandlers
        )
            : base(
                entity,
                entityDefinition,
                discoveryTopic,
                discoveryMessage,
                deleteMessage,
                discoveryMessageQualityOfServiceLevel,
                retainDiscoveryMessage,
                commandHandlers,
                stateMessageQualityOfServiceLevel,
                retainStateMessages,
                stateChangeHandlers
            )
        {
        }
    }
}
