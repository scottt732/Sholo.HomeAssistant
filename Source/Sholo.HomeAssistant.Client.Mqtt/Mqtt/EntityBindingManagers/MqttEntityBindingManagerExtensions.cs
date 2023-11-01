using System;
using System.Linq;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindings;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

public static class MqttEntityBindingManagerExtensions
{
    public static IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> GetBindingByName<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string name)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
        => manager.EntityConfigurations
            .SingleOrDefault(x => x.EntityConfiguration.EntityDefinition.Name.Equals(name, StringComparison.Ordinal));

    public static IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> GetBindingByUniqueId<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string uniqueId)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
        => manager.EntityConfigurations
            .SingleOrDefault(x => x.EntityConfiguration.EntityDefinition.UniqueId.Equals(uniqueId, StringComparison.Ordinal));

    public static TEntity GetEntityByName<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string name)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : class, IEntity
        where TEntityDefinition : IEntityDefinition
    {
        var binding = manager.GetBindingByName(name);
        return binding?.EntityConfiguration.Entity;
    }

    public static TEntity GetEntityByUniqueId<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string uniqueId)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : class, IEntity
        where TEntityDefinition : IEntityDefinition
    {
        var binding = manager.GetBindingByUniqueId(uniqueId);
        return binding?.EntityConfiguration.Entity;
    }
}
