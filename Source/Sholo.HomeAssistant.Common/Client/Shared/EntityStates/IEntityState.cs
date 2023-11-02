using System;
using System.Collections.Generic;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.Shared.EntityStates;

[PublicAPI]
public interface IEntityState
{
    string EntityId { get; }
    DateTimeOffset? LastChanged { get; }
    DateTimeOffset? LastUpdated { get; }
    IEntityStateContext Context { get; }
    string RawState { get; }
    IDictionary<string, object> RawAttributes { get; }
}

[PublicAPI]
public interface IEntityState<out TStateAttributes> : IEntityState
    where TStateAttributes : class
{
    TStateAttributes Attributes { get; }
}

[PublicAPI]
public interface IEntityState<out TStateValue, out TStateAttributes> : IEntityState<TStateAttributes>
    where TStateAttributes : class
{
    TStateValue State { get; }
}
