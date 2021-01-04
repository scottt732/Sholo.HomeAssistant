using System;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.Mqtt.Consumer;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindings
{
    public interface IMqttEntityBinding<out TMqttEntityConfiguration, TEntity, TEntityDefinition> : IDisposable
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        TMqttEntityConfiguration EntityConfiguration { get; }

        void Bind(IMqttMessageBus messageBus, bool sendDiscovery = true);
        void SendDiscovery();
        void Delete();
    }
}
