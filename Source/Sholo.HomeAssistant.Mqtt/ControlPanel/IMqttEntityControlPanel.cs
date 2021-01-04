using System;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.Mqtt.ApplicationBuilderConfiguration;
using Sholo.Mqtt.ApplicationProvider;

namespace Sholo.HomeAssistant.Mqtt.ControlPanel
{
    [PublicAPI]
    public interface IMqttEntityControlPanel : IConfigureMqttApplicationBuilder, IDisposable
    {
        void BindAll(IMqttApplicationProvider mqttApplicationProvider, IMqttMessageBus mqttMessageBus, bool sendDiscovery = true);
        void SendDiscoveryAll();
        void DeleteAll();

        public IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> StatefulEntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition;

        public IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> EntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition;

        void AddEntity<TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition;

        void AddStatefulEntity<TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition;
    }
}
