using JetBrains.Annotations;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations
{
    [PublicAPI]
    public interface IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        TEntity Entity { get; }
        TEntityDefinition EntityDefinition { get; }
        ICommandHandler<TEntity, TEntityDefinition>[] CommandHandlers { get; }

        string DiscoveryTopic { get; }
        MqttApplicationMessage DiscoveryMessage { get; }
        MqttApplicationMessage DeleteMessage { get; }
        MqttQualityOfServiceLevel? DiscoveryMessageQualityOfServiceLevel { get; }
        bool RetainDiscoveryMessage { get; }
    }
}
