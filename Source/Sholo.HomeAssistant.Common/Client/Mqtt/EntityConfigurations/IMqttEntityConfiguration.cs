using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

[PublicAPI]
public interface IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    TEntity Entity { get; }
    TEntityDefinition EntityDefinition { get; }
    ICommandHandler<TEntity, TEntityDefinition>[] CommandHandlers { get; }

    string DiscoveryTopic { get; }
    IApplicationMessage DiscoveryMessage { get; }
    IApplicationMessage DeleteMessage { get; }
    QualityOfServiceLevel? DiscoveryMessageQualityOfServiceLevel { get; }
    bool RetainDiscoveryMessage { get; }
}
