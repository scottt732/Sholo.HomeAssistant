using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

[PublicAPI]
public class SwitchMqttEntityConfiguration : BaseMqttStatefulEntityConfiguration<ISwitch, ISwitchEntityDefinition>, ISwitchMqttEntityConfiguration
{
    public SwitchMqttEntityConfiguration(
        ISwitch entity,
        ISwitchEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<ISwitch, ISwitchEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<ISwitch, ISwitchEntityDefinition>[] stateChangeHandlers
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
