using System;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    [PublicAPI]
    public abstract class BaseEntityStateDeserializer<TState> : IEntityStateDeserializer
        where TState : EntityState
    {
        public abstract string TargetEntityId { get; }
        protected abstract EventMessage<StateChangePayload<TState>> CreateTypedTarget();

        public Type TargetStateChangeEventMessageType { get; } = typeof(EventMessage<StateChangePayload<TState>>);
        public Type EntityStateType { get; } = typeof(TState);
    }
}
