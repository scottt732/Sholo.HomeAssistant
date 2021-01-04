using System;
using System.IO;
using System.Reactive;
using System.Text;
using MQTTnet;
using MQTTnet.Protocol;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Mqtt.Dispatchers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers
{
    public abstract class BaseStateChangeHandler<TEntity, TEntityDefinition> : IStateChangeHandler<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        private JsonSerializer JsonSerializer { get; } = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);

        public IDisposable Bind(
            IMqttMessageBus target,
            TEntity entity,
            TEntityDefinition entityDefinition,
            MqttQualityOfServiceLevel? qualityOfServiceLevel,
            bool retainMessages
        ) =>
            BindObserver(
                target,
                entity,
                entityDefinition,
                qualityOfServiceLevel,
                retainMessages
            );

        protected abstract string GetStateMessagePayload(TEntityDefinition entityDefinition, TEntity entity);
        protected abstract IObservable<Unit> GetStateChangeDetector(TEntity entity);

        protected string SerializeJson<TObject>(TObject entity)
        {
            var sb = new StringBuilder();
            using var sw = new StringWriter(sb);

            JsonSerializer.Serialize(sw, entity);

            return sb.ToString();
        }

        private IDisposable BindObserver(
            IMqttMessageBus target,
            TEntity entity,
            TEntityDefinition entityDefinition,
            MqttQualityOfServiceLevel? qualityOfServiceLevel,
            bool retainMessages)
            => GetStateChangeDetector(entity)
                .Subscribe(
                    state =>
                    {
                        var payload = GetStateMessagePayload(entityDefinition, entity);

                        var messageBuilder = new MqttApplicationMessageBuilder()
                            .WithTopic(entityDefinition.StateTopic)
                            .WithPayload(payload)
                            .WithRetainFlag(retainMessages);

                        if (qualityOfServiceLevel.HasValue)
                        {
                            messageBuilder = messageBuilder.WithQualityOfServiceLevel(qualityOfServiceLevel.Value);
                        }

                        var message = messageBuilder.Build();

                        if (message.Payload != null)
                        {
                            target.PublishMessage(message);
                        }
                    }
                );

        // I think we want to allow re-publishing unchanged values.
        // An app that publishes sensor data via MQTT but listens to HA state changes via WebSockets should be able to
        // re-publish unchanged values when the WebSockets connection recovers from an interruption.
        // DistinctUntilChanged would prevent that
    }
}
