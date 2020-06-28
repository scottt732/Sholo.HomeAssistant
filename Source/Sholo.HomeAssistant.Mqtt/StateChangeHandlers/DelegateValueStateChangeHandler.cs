using System;
using System.Reactive;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers
{
    public class DelegateValueStateChangeHandler<TEntity, TEntityDefinition> : BaseStateChangeHandler<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        private Func<TEntityDefinition, TEntity, string> StateMessagePayloadSelector { get; }
        private Func<TEntity, IObservable<Unit>> StateChangeDetectionSelector { get; }

        public DelegateValueStateChangeHandler(
            Func<TEntityDefinition, TEntity, string> stateMessagePayloadSelector,
            Func<TEntity, IObservable<Unit>> stateChangeDetectionSelector
        )
        {
            StateMessagePayloadSelector = stateMessagePayloadSelector ?? throw new ArgumentNullException(nameof(stateMessagePayloadSelector));
            StateChangeDetectionSelector = stateChangeDetectionSelector ?? throw new ArgumentNullException(nameof(stateChangeDetectionSelector));
        }

        protected override string GetStateMessagePayload(TEntityDefinition entityDefinition, TEntity entity)
            => StateMessagePayloadSelector(entityDefinition, entity);

        protected override IObservable<Unit> GetStateChangeDetector(TEntity entity)
            => StateChangeDetectionSelector(entity);
    }
}
