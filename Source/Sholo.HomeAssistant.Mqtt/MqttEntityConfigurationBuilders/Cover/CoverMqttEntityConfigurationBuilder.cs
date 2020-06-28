using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Cover;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Cover
{
    public class CoverMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<CoverMqttEntityConfigurationBuilder, ICoverMqttEntityConfigurationBuilder, ICover, ICoverEntityDefinition, CoverEntityDefinitionBuilder, ICoverMqttEntityConfiguration>,
        ICoverMqttEntityConfigurationBuilder
    {
        public override ICoverMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => this;

        public override ICoverMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        protected override ICoverMqttEntityConfiguration Build(
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
            => new CoverMqttEntityConfiguration(
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

        public CoverMqttEntityConfigurationBuilder()
            : base(ComponentType.Cover)
        {
        }
    }
}
