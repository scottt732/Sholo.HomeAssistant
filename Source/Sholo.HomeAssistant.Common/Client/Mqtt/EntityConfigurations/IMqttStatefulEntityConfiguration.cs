using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;

public interface IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition> : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    QualityOfServiceLevel? StateMessageQualityOfServiceLevel { get; }
    bool RetainStateMessages { get; }
    IStateChangeHandler<TEntity, TEntityDefinition>[] StateChangeHandlers { get; }
}
