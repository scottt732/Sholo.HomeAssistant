using System;
using Sholo.HomeAssistant.Client.Shared.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

[PublicAPI]
public abstract class BaseEntityStateDeserializer<TState> : IEntityStateDeserializer
    where TState : IEntityState
{
    public abstract string TargetEntityId { get; }
    protected abstract IEventMessage<StateChangePayload<TState>> CreateTypedTarget();

    public Type TargetStateChangeEventMessageType { get; } = typeof(IEventMessage<StateChangePayload<TState>>);
    public Type EntityStateType { get; } = typeof(TState);
}
