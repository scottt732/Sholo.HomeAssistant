using System;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindings;

[PublicAPI]
public class MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public bool IsBound { get; private set; }
    public TMqttEntityConfiguration EntityConfiguration { get; }

    protected IMqttMessageBus? MessageBus { get; private set; }

    public MqttEntityBinding(TMqttEntityConfiguration entityConfiguration)
    {
        EntityConfiguration = entityConfiguration;
    }

    public virtual void Bind(IMqttMessageBus messageBus, bool sendDiscovery)
    {
        if (MessageBus != null || IsBound)
        {
            throw new InvalidOperationException($"{nameof(Bind)} can only be called once");
        }

        MessageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));

        if (sendDiscovery)
        {
            MessageBus.PublishMessage(EntityConfiguration.DiscoveryMessage);
        }

        IsBound = true;

        if (EntityConfiguration.EntityDefinition.ObjectId?.EndsWith("_countdown", StringComparison.OrdinalIgnoreCase) ?? false)
        {
            Delete();
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
