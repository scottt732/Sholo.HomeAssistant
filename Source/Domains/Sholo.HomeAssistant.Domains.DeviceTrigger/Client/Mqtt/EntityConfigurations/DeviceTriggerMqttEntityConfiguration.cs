using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public class DeviceTriggerMqttEntityConfiguration : BaseMqttEntityConfiguration<IDeviceTrigger, IDeviceTriggerEntityDefinition>, IDeviceTriggerMqttEntityConfiguration
{
    public DeviceTriggerMqttEntityConfiguration(
        IDeviceTrigger entity,
        IDeviceTriggerEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<IDeviceTrigger, IDeviceTriggerEntityDefinition>[] commandHandlers
    )
        : base(
            entity,
            entityDefinition,
            discoveryTopic,
            discoveryMessage,
            deleteMessage,
            discoveryMessageQualityOfServiceLevel,
            retainDiscoveryMessage,
            commandHandlers
        )
    {
    }
}
