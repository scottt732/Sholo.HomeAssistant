using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Vacuum;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Vacuum
{
    public class VacuumMqttEntityConfigurationBuilder :
        BaseMqttStatefulEntityConfigurationBuilder<VacuumMqttEntityConfigurationBuilder, IVacuumMqttEntityConfigurationBuilder, IVacuum, IVacuumEntityDefinition, VacuumEntityDefinitionBuilder, IVacuumMqttEntityConfiguration>,
        IVacuumMqttEntityConfigurationBuilder
    {
        public override IVacuumMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
            => this;

        public override IVacuumMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => this;

        protected override IVacuumMqttEntityConfiguration Build(
            IVacuum entity,
            IVacuumEntityDefinition entityDefinition,
            string discoveryTopic,
            MqttApplicationMessage discoveryMessage,
            MqttApplicationMessage deleteMessage,
            MqttQualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
            bool retainDiscoveryMessage,
            ICommandHandler<IVacuum, IVacuumEntityDefinition>[] commandHandlers,
            MqttQualityOfServiceLevel? stateMessageQualityOfServiceLevel,
            bool retainStateMessages,
            IStateChangeHandler<IVacuum, IVacuumEntityDefinition>[] stateChangeHandlers)
            => new VacuumMqttEntityConfiguration(
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

        public VacuumMqttEntityConfigurationBuilder()
            : base(ComponentType.Vacuum)
        {
        }
    }
}
