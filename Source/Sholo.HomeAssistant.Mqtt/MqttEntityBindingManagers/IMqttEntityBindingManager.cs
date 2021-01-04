using System;
using System.Collections.Generic;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.Mqtt.ApplicationBuilder;
using Sholo.Mqtt.ApplicationProvider;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers
{
    public interface IMqttEntityBindingManager : IDisposable
    {
        void BindAll(IMqttApplicationProvider mqttApplicationProvider, IMqttMessageBus mqttMessageBus, bool sendDiscovery = true);
        void SendDiscoveryAll();
        void DeleteAll();
        void ConfigureCommands(IMqttApplicationBuilder mqttApplicationBuilder);
    }

    public interface IMqttEntityBindingManager<TEntity> : IMqttEntityBindingManager
        where TEntity : IEntity
    {
    }

    public interface IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManager<TEntity>
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        IList<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> EntityConfigurations { get; }
    }
}
