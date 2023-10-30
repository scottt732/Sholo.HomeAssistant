using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public class LightMqttEntityConfiguration : BaseMqttStatefulEntityConfiguration<ILight, ILightEntityDefinition>, ILightMqttEntityConfiguration
{
    public LightMqttEntityConfiguration(
        ILight entity,
        ILightEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<ILight, ILightEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<ILight, ILightEntityDefinition>[] stateChangeHandlers
    )
        : base(
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
        )
    {
    }
}
