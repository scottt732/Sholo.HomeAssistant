using Sholo.HomeAssistant.Mqtt.CommandHandlers.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.DeviceTrigger;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.DeviceTrigger
{
    public class DeviceTriggerMqttEntityConfigurationBuilder :
        BaseMqttEntityConfigurationBuilder<DeviceTriggerMqttEntityConfigurationBuilder, IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTrigger, IDeviceTriggerEntityDefinition, DeviceTriggerEntityDefinitionBuilder, IDeviceTriggerMqttEntityConfiguration>,
        IDeviceTriggerMqttEntityConfigurationBuilder
    {
        public override IDeviceTriggerMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
            => WithCommandHandler(new DeviceTriggerCommandHandler());

        public override IDeviceTriggerMqttEntityConfiguration Build()
            => new DeviceTriggerMqttEntityConfiguration(
                Entity,
                EntityDefinition,
                DiscoveryTopic,
                DiscoveryMessage,
                DeleteMessage,
                DiscoveryMessageQualityOfServiceLevel,
                RetainDiscoveryMessages,
                CommandHandlers.ToArray()
            );

        public DeviceTriggerMqttEntityConfigurationBuilder()
            : base(ComponentType.DeviceTrigger)
        {
        }
    }
}
