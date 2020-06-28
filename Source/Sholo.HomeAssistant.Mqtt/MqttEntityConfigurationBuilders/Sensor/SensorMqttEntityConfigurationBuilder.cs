using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Sensor;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Sensor;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Sensor
{
    public class SensorMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<SensorMqttEntityConfigurationBuilder, ISensorMqttEntityConfigurationBuilder, ISensor, ISensorEntityDefinition, SensorEntityDefinitionBuilder, ISensorMqttEntityConfiguration>,
        ISensorMqttEntityConfigurationBuilder
    {
        public override ISensorMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => WithStateChangeHandler(new SensorValuesStateChangeHandler());

        public override ISensorMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        protected override ISensorMqttEntityConfiguration Build(
            ISensor entity,
            ISensorEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<ISensor, ISensorEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<ISensor, ISensorEntityDefinition>[] stateChangeHandlers
        )
            => new SensorMqttEntityConfiguration(
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
                stateChangeHandlers);

        public SensorMqttEntityConfigurationBuilder()
            : base(ComponentType.Sensor)
        {
        }
    }
}
