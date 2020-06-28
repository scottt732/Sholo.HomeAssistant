using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Light;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Light
{
    public class LightMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<LightMqttEntityConfigurationBuilder, ILightMqttEntityConfigurationBuilder, ILight, ILightEntityDefinition, LightEntityDefinitionBuilder, ILightMqttEntityConfiguration>,
        ILightMqttEntityConfigurationBuilder
    {
        public override ILightMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => this;

        public override ILightMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        protected override ILightMqttEntityConfiguration Build(
            ILight entity,
            ILightEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<ILight, ILightEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<ILight, ILightEntityDefinition>[] stateChangeHandlers
        )
            => new LightMqttEntityConfiguration(
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

        public LightMqttEntityConfigurationBuilder()
            : base(ComponentType.Light)
        {
        }
    }
}
