using System.Linq;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers
{
    public static class MqttEntityBindingManagerExtensions
    {
        public static IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> GetBindingByName<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string name)
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
            => manager.EntityConfigurations
                .SingleOrDefault(x => x.EntityConfiguration.EntityDefinition.Name.Equals(name));

        public static IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> GetBindingByUniqueId<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string uniqueId)
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
            => manager.EntityConfigurations
                .SingleOrDefault(x => x.EntityConfiguration.EntityDefinition.UniqueId.Equals(uniqueId));

        public static TEntity GetEntityByName<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string name)
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : class, IEntity
            where TEntityDefinition : IEntityDefinition
        {
            var binding = manager.GetBindingByName(name);
            return binding?.EntityConfiguration.Entity;
        }

        public static TEntity GetEntityByUniqueId<TMqttEntityConfiguration, TEntity, TEntityDefinition>(this IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> manager, string uniqueId)
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : class, IEntity
            where TEntityDefinition : IEntityDefinition
        {
            var binding = manager.GetBindingByUniqueId(uniqueId);
            return binding?.EntityConfiguration.Entity;
        }
    }
}
