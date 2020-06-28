using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations
{
    public interface IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition> : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        MqttQualityOfServiceLevel? StateMessageQualityOfServiceLevel { get; }
        bool RetainStateMessages { get; }
        IStateChangeHandler<TEntity, TEntityDefinition>[] StateChangeHandlers { get; }
    }
}
