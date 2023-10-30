using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

public class HomeAssistantMqttConfigurationBuilder : IHomeAssistantMqttConfigurationBuilder
{
    public IHomeAssistantServiceCollection ServiceCollection { get; }

    public HomeAssistantMqttConfigurationBuilder(IHomeAssistantServiceCollection homeAssistantServiceCollection)
    {
        ServiceCollection = homeAssistantServiceCollection ?? throw new ArgumentNullException(nameof(homeAssistantServiceCollection));
    }

    public void TryRegisterEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        ServiceCollection.TryAddSingleton<IEntityBindingManager, MqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
    }

    public void TryRegisterStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        ServiceCollection.TryAddSingleton<IEntityBindingManager, MqttStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
    }
}
