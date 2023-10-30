using System;
using System.Reactive;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public interface IStateChangeHandler<in TEntity, in TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    string GetStateMessagePayload(TEntityDefinition entityDefinition, TEntity entity);
    IObservable<Unit> GetStateChangeDetector(TEntity entity);
    IDisposable Bind(
        IMqttMessageBus target,
        TEntity entity,
        TEntityDefinition entityDefinition,
        QualityOfServiceLevel? qualityOfServiceLevel,
        bool retainMessages
    );
}
