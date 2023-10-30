using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public class CameraMqttEntityConfiguration : BaseMqttEntityConfiguration<ICamera, ICameraEntityDefinition>, ICameraMqttEntityConfiguration
{
    public CameraMqttEntityConfiguration(
        ICamera entity,
        ICameraEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessages,
        ICommandHandler<ICamera, ICameraEntityDefinition>[] commandHandlers
    )
        : base(
            entity,
            entityDefinition,
            discoveryTopic,
            discoveryMessage,
            deleteMessage,
            discoveryMessageQualityOfServiceLevel,
            retainDiscoveryMessages,
            commandHandlers
        )
    {
    }
}
