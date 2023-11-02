using System;
using System.IO;
using System.Reactive;
using System.Text;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public abstract class BaseStateChangeHandler<TEntity, TEntityDefinition> : IStateChangeHandler<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    private JsonSerializer JsonSerializer { get; } = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);

    public IDisposable Bind(
        IMqttMessageBus target,
        TEntity entity,
        TEntityDefinition entityDefinition,
        QualityOfServiceLevel? qualityOfServiceLevel,
        bool retainMessages
    )
    {
        var stateChangeDetector = GetStateChangeDetector(entity);

        return stateChangeDetector
            .Subscribe(
                _ =>
                {
                    var stateMessagePayload = GetStateMessagePayload(entityDefinition, entity);

                    var messageBuilder = new ApplicationMessageBuilder()
                        .WithTopic(entityDefinition.StateTopic)
                        .WithPayload(stateMessagePayload)
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
    }

    public abstract string GetStateMessagePayload(TEntityDefinition entityDefinition, TEntity entity);
    public abstract IObservable<Unit> GetStateChangeDetector(TEntity entity);

    protected string SerializeJson<TObject>(TObject entity)
    {
        var sb = new StringBuilder();
        using var sw = new StringWriter(sb);

        JsonSerializer.Serialize(sw, entity);

        return sb.ToString();
    }

    // I think we want to allow re-publishing unchanged values.
    // An app that publishes sensor data via MQTT but listens to HA state changes via WebSockets should be able to
    // re-publish unchanged values when the WebSockets connection recovers from an interruption.
    // DistinctUntilChanged would prevent that
}
