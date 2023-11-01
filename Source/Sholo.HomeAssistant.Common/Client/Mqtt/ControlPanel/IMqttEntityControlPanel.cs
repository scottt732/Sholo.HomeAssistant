using System;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.ControlPanel;

[PublicAPI]
public interface IMqttEntityControlPanel : IDisposable
{
    void SendDiscoveryAll();
    void DeleteAll();

    public IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> StatefulEntitiesOfType<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;

    public IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> EntitiesOfType<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    void AddEntity<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    void AddStatefulEntity<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;
}
