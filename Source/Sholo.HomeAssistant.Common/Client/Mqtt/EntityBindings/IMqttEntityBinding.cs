using System;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindings;

public interface IMqttEntityBinding : IDisposable
{
    bool IsBound { get; }
    void Bind(IMqttMessageBus messageBus, bool sendDiscovery);
    void SendDiscovery();
    void Delete();
}

public interface IMqttEntityBinding<out TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBinding
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    TMqttEntityConfiguration EntityConfiguration { get; }
}
