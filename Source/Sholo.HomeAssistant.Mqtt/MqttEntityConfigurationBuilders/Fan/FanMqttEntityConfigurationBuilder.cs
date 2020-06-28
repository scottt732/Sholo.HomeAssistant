using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Fan;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Fan
{
    public class FanMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<FanMqttEntityConfigurationBuilder, IFanMqttEntityConfigurationBuilder, IFan, IFanEntityDefinition, FanEntityDefinitionBuilder, IFanMqttEntityConfiguration>,
        IFanMqttEntityConfigurationBuilder
    {
        public override IFanMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => this;

        public override IFanMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        protected override IFanMqttEntityConfiguration Build(
            IFan entity,
            IFanEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<IFan, IFanEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<IFan, IFanEntityDefinition>[] stateChangeHandlers
        )
            => new FanMqttEntityConfiguration(
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

        public FanMqttEntityConfigurationBuilder()
            : base(ComponentType.Fan)
        {
        }
    }
}
