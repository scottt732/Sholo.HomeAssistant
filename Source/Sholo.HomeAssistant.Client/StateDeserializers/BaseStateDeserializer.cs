using System;
using System.Collections.Generic;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    public abstract class BaseStateDeserializer<TState> : IStateDeserializer
        where TState : EntityState
    {
        public abstract string TargetDomain { get; }
        public abstract bool CanDeserialize(IDictionary<string, object> attributes);

        public Type TargetStateChangeEventMessageType { get; } = typeof(EventMessage<StateChangePayload<TState>>);
        public Type EntityStateType { get; } = typeof(TState);
    }
}