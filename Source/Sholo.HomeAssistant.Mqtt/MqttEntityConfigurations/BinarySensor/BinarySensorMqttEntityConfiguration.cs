using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.BinarySensor
{
    public class BinarySensorMqttEntityConfiguration : BaseMqttStatefulEntityConfiguration<IBinarySensor, IBinarySensorEntityDefinition>, IBinarySensorMqttEntityConfiguration
    {
        public BinarySensorMqttEntityConfiguration(
            IBinarySensor entity,
            IBinarySensorEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<IBinarySensor, IBinarySensorEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<IBinarySensor, IBinarySensorEntityDefinition>[] stateChangeHandlers
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
