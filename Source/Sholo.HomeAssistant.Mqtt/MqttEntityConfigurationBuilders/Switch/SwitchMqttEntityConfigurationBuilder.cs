using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.CommandHandlers.Switch;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Switch;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Switch
{
    public class SwitchMqttEntityConfigurationBuilder
        : BaseMqttStatefulEntityConfigurationBuilder<SwitchMqttEntityConfigurationBuilder, ISwitchMqttEntityConfigurationBuilder, ISwitch, ISwitchEntityDefinition, SwitchEntityDefinitionBuilder, ISwitchMqttEntityConfiguration>,
            ISwitchMqttEntityConfigurationBuilder
    {
        public override ISwitchMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => WithStateChangeHandler(new SwitchStateChangeHandler());

        public override ISwitchMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => WithCommandHandler(new SwitchCommandHandler());

        protected override ISwitchMqttEntityConfiguration Build(
            ISwitch entity,
            ISwitchEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<ISwitch, ISwitchEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<ISwitch, ISwitchEntityDefinition>[] stateChangeHandlers
        )
            => new SwitchMqttEntityConfiguration(
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

        public SwitchMqttEntityConfigurationBuilder()
            : base(ComponentType.Switch)
        {
        }
    }
}
