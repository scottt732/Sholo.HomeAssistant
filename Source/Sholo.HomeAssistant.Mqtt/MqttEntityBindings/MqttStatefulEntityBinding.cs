using System;
using System.Collections.Generic;
using System.Linq;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindings
{
    public class MqttStatefulEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> : MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        private IDictionary<string, IDisposable> SubscriptionsByDiscoveryTopic { get; } = new Dictionary<string, IDisposable>();

        public MqttStatefulEntityBinding(
            TMqttEntityConfiguration entityConfiguration
        )
            : base(entityConfiguration)
        {
        }

        public override void Bind(IMqttMessageBus messageBus, bool sendDiscovery = true)
        {
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
                foreach (var keyValuePair in this.SubscriptionsByDiscoveryTopic.ToArray())
                {
                    keyValuePair.Value.Dispose();
                }
            }

            base.Dispose(true);
        }
    }
}
