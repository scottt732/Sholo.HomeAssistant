using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IHomeAssistantMqttConfigurationBuilder
{
    IHomeAssistantServiceCollection ServiceCollection { get; }

    void TryRegisterEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    void TryRegisterStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;
}
