using System;
using System.Collections.Generic;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindings;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

[PublicAPI]
public interface IEntityBindingManager : IDisposable
{
    IDomain Domain { get; }

    event EventHandler RebuildRequired;

    void BindAll(IMqttMessageBus mqttMessageBus, bool sendDiscovery);
    void SendDiscoveryAll();
    void DeleteAll();
}

// ReSharper disable once UnusedTypeParameter - Used to disambiguate in DI
[PublicAPI]
public interface IEntityBindingManager<TEntity> : IEntityBindingManager
    where TEntity : IEntity
{
}

[PublicAPI]
public interface IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IEntityBindingManager<TEntity>
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    IList<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> EntityConfigurations { get; }
}
