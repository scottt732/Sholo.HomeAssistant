using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IHomeAssistantMqttClientConfigurationBuilder
{
    IConfiguration Configuration { get; }
    IServiceCollection ServiceCollection { get; }

    IHomeAssistantMqttClientConfigurationBuilder AddDomain<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    IHomeAssistantMqttClientConfigurationBuilder AddStatefulDomain<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;
}
