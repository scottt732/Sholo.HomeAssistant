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

    public IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> StatefulEntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>(IDomain domain)
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;

    public IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> EntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>(IDomain domain)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    void AddEntity<TMqttEntityConfiguration, TEntity, TEntityDefinition>(IDomain domain, TMqttEntityConfiguration entityConfiguration)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition;

    void AddStatefulEntity<TMqttEntityConfiguration, TEntity, TEntityDefinition>(IDomain domain, TMqttEntityConfiguration entityConfiguration)
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition;
}
