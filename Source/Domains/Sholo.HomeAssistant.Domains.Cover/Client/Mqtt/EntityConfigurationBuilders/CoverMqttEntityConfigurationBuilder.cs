using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class CoverMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<CoverMqttEntityConfigurationBuilder, ICoverMqttEntityConfigurationBuilder, ICover, ICoverEntityDefinition, CoverEntityDefinitionBuilder, ICoverMqttEntityConfiguration>,
    ICoverMqttEntityConfigurationBuilder
{
    public override ICoverMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => this;

    public override ICoverMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override ICoverMqttEntityConfiguration Build(
        ICover entity,
        ICoverEntityDefinition entityDefinition,
        string discoveryTopic,
        IApplicationMessage discoveryMessage,
        IApplicationMessage deleteMessage,
        QualityOfServiceLevel? discoveryMessageQualityOfServiceLevel,
        bool retainDiscoveryMessage,
        ICommandHandler<ICover, ICoverEntityDefinition>[] commandHandlers,
        QualityOfServiceLevel? stateMessageQualityOfServiceLevel,
        bool retainStateMessages,
        IStateChangeHandler<ICover, ICoverEntityDefinition>[] stateChangeHandlers
    )
        => new CoverMqttEntityConfiguration(
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

    public CoverMqttEntityConfigurationBuilder()
        : base("cover")
    {
    }
}
