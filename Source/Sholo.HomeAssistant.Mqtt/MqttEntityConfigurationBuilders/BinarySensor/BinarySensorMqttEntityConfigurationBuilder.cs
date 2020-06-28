using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.BinarySensor;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers.BinarySensor;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.BinarySensor
{
    public class BinarySensorMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<BinarySensorMqttEntityConfigurationBuilder, IBinarySensorMqttEntityConfigurationBuilder, IBinarySensor, IBinarySensorEntityDefinition, BinarySensorEntityDefinitionBuilder, IBinarySensorMqttEntityConfiguration>,
        IBinarySensorMqttEntityConfigurationBuilder
    {
        public override IBinarySensorMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => WithStateChangeHandler(new BinarySensorStateChangeHandler());

        public override IBinarySensorMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        protected override IBinarySensorMqttEntityConfiguration Build(
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
            => new BinarySensorMqttEntityConfiguration(
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
            );

        public BinarySensorMqttEntityConfigurationBuilder()
            : base(ComponentType.BinarySensor)
        {
        }
    }
}
