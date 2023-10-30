using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class DeviceTriggerMqttEntityConfigurationBuilder :
    BaseStatelessMqttEntityConfigurationBuilder<DeviceTriggerMqttEntityConfigurationBuilder, IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTrigger, IDeviceTriggerEntityDefinition, DeviceTriggerEntityDefinitionBuilder, IDeviceTriggerMqttEntityConfiguration>,
    IDeviceTriggerMqttEntityConfigurationBuilder
{
    public override IDeviceTriggerMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => WithCommandHandler(new DeviceTriggerCommandHandler());

    protected override IDeviceTriggerMqttEntityConfiguration Build(
        IDeviceTrigger entity,
        IDeviceTriggerEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IDeviceTrigger, IDeviceTriggerEntityDefinition>[] commandHandlers
    )
        => new DeviceTriggerMqttEntityConfiguration(
            entity,
            entityDefinition,
            discoveryTopic,
            discoveryMessage,
            deleteMessage,
            discoveryMessageQualityOfServiceLevel,
            retainDiscoveryMessage,
            commandHandlers
        );

    public DeviceTriggerMqttEntityConfigurationBuilder()
        : base("device_trigger")
    {
    }
}
