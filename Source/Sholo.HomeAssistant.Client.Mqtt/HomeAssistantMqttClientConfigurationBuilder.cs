using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client;

public class HomeAssistantMqttClientConfigurationBuilder : IHomeAssistantMqttClientConfigurationBuilder
{
    public IConfiguration Configuration { get; }
    public IServiceCollection ServiceCollection { get; }

    public HomeAssistantMqttClientConfigurationBuilder(IHomeAssistantConfigurationBuilder homeAssistantConfigurationBuilder)
    {
        Configuration = homeAssistantConfigurationBuilder.Configuration.GetSection("client:mqtt");
        ServiceCollection = homeAssistantConfigurationBuilder.Services;
    }

    public IHomeAssistantMqttClientConfigurationBuilder AddDomain<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        ServiceCollection.TryAddSingleton<IEntityBindingManager, MqttEntityBindingManager<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
        return this;
    }

    public IHomeAssistantMqttClientConfigurationBuilder AddStatefulDomain<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        ServiceCollection.TryAddSingleton<IEntityBindingManager, MqttStatefulEntityBindingManager<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
        return this;
    }
}
