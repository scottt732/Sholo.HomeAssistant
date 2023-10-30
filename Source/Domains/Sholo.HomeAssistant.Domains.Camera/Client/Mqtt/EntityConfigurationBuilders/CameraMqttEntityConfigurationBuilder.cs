using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class CameraMqttEntityConfigurationBuilder :
    BaseMqttEntityConfigurationBuilder<CameraMqttEntityConfigurationBuilder, ICameraMqttEntityConfigurationBuilder, ICamera, ICameraEntityDefinition, CameraEntityDefinitionBuilder, ICameraMqttEntityConfiguration>,
    ICameraMqttEntityConfigurationBuilder
{
    public override ICameraMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    public override ICameraMqttEntityConfiguration Build()
        => Build(
            Entity ?? throw new ArgumentNullException(nameof(Entity)),
            EntityDefinition ?? throw new ArgumentNullException(nameof(EntityDefinition)),
            DiscoveryTopic ?? throw new ArgumentNullException(nameof(DiscoveryTopic)),
            DiscoveryMessage ?? throw new ArgumentNullException(nameof(DiscoveryMessage)),
            DeleteMessage ?? throw new ArgumentNullException(nameof(DeleteMessage)),
            DiscoveryMessageQualityOfServiceLevel,
            RetainDiscoveryMessages,
            CommandHandlers.ToArray()
        );

    private ICameraMqttEntityConfiguration Build(
        ICamera entity,
        ICameraEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool? retainDiscoveryMessages,
        ICommandHandler<ICamera, ICameraEntityDefinition>[] commandHandlers)
        => new CameraMqttEntityConfiguration(
            entity,
            entityDefinition,
            discoveryTopic,
            discoveryMessage,
            deleteMessage,
            discoveryMessageQualityOfServiceLevel,
            retainDiscoveryMessages ?? true,
            commandHandlers
        );

    public CameraMqttEntityConfigurationBuilder()
        : base("camera")
    {
    }
}
