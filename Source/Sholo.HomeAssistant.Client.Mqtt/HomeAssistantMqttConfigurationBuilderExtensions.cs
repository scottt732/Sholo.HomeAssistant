using Microsoft.Extensions.DependencyInjection.Extensions;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static void TryRegisterEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder
    )
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        configurationBuilder.ServiceCollection
            .TryAddSingleton<
                IEntityBindingManager,
                MqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
    }

    public static void TryRegisterStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder
    )
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        configurationBuilder.ServiceCollection
            .TryAddSingleton<
                IEntityBindingManager,
                MqttStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
    }
}
