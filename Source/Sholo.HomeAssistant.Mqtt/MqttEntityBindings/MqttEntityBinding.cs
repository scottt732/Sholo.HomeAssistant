using System;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindings
{
    public class MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        public TMqttEntityConfiguration EntityConfiguration { get; }

        protected IMqttMessageBus MessageBus { get; private set; }

        public MqttEntityBinding(TMqttEntityConfiguration entityConfiguration)
        {
            EntityConfiguration = entityConfiguration;
        }

        public virtual void Bind(IMqttMessageBus messageBus, bool sendDiscovery = true)
        {
            if (MessageBus != null)
            {
                throw new InvalidOperationException($"{nameof(Bind)} can only be called once");
            }

            MessageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));

            if (sendDiscovery)
            {
                MessageBus.PublishMessage(EntityConfiguration.DiscoveryMessage);
            }
        }

        public void SendDiscovery()
        {
            if (MessageBus == null)
            {
                throw new InvalidOperationException($"Cannot call {nameof(SendDiscovery)} without first calling {nameof(Bind)}");
            }

            MessageBus.PublishMessage(EntityConfiguration.DiscoveryMessage);
        }

        public void Delete()
        {
            if (MessageBus == null)
            {
                throw new InvalidOperationException($"Cannot call {nameof(Delete)} without first calling {nameof(Bind)}");
            }

            MessageBus.PublishMessage(EntityConfiguration.DeleteMessage);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
