using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant;

public interface IHomeAssistantDomainsConfigurationBuilder
{
    IServiceCollection ServiceCollection { get; }

    // HTTP
    IHomeAssistantDomainsConfigurationBuilder AddDomain<TStateDeserializer>()
        where TStateDeserializer : class, IStateDeserializer;

    // MQTT
    IHomeAssistantDomainsConfigurationBuilder TryRegisterEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    // MQTT
    IHomeAssistantDomainsConfigurationBuilder TryRegisterStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;
}
