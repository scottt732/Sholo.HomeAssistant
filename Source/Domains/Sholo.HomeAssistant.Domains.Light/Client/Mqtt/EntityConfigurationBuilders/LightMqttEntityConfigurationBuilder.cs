using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;

public class LightMqttEntityConfigurationBuilder :
    BaseMqttStatefulEntityConfigurationBuilder<LightMqttEntityConfigurationBuilder, ILightMqttEntityConfigurationBuilder, ILight, ILightEntityDefinition, LightEntityDefinitionBuilder, ILightMqttEntityConfiguration>,
    ILightMqttEntityConfigurationBuilder
{
    public override ILightMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => this;

    public override ILightMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override ILightMqttEntityConfiguration Build(
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
        => new LightMqttEntityConfiguration(
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

    public LightMqttEntityConfigurationBuilder()
        : base("light")
    {
    }
}
