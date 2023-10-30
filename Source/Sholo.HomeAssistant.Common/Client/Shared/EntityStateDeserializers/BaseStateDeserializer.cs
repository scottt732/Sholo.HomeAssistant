using System;
using System.Collections.Generic;
using Sholo.HomeAssistant.Client.Shared.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

public abstract class BaseStateDeserializer<TState> : IStateDeserializer
    where TState : IEntityState
{
    public abstract string TargetDomain { get; }
    public abstract bool CanDeserialize(IDictionary<string, object> attributes);

    public Type TargetStateChangeEventMessageType { get; } = typeof(IEventMessage<StateChangePayload<TState>>);
    public Type EntityStateType { get; } = typeof(TState);
}
