using System;
using System.Collections.Generic;
using System.Linq;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindings;

public class MqttStatefulEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> : MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>
    where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    private Dictionary<string, IDisposable> SubscriptionsByDiscoveryTopic { get; } = new();

    public MqttStatefulEntityBinding(
        TMqttEntityConfiguration entityConfiguration
    )
        : base(entityConfiguration)
    {
    }

    public override void Bind(IMqttMessageBus messageBus, bool sendDiscovery)
    {
        if (MessageBus != null || IsBound)
        {
            throw new InvalidOperationException($"{nameof(Bind)} can only be called once");
        }

        foreach (var stateChangeHandler in EntityConfiguration.StateChangeHandlers)
        {
            SubscriptionsByDiscoveryTopic.Add(
                EntityConfiguration.DiscoveryTopic,
                stateChangeHandler.Bind(
                    messageBus,
                    EntityConfiguration.Entity,
                    EntityConfiguration.EntityDefinition,
                    EntityConfiguration.StateMessageQualityOfServiceLevel,
                    EntityConfiguration.RetainStateMessages
                )
            );
        }

        base.Bind(messageBus, sendDiscovery);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (var keyValuePair in SubscriptionsByDiscoveryTopic.ToArray())
            {
                keyValuePair.Value.Dispose();
            }
        }

        base.Dispose(true);
    }
}
