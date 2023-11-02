using Sholo.HomeAssistant.Client.Shared.EntityStates;

namespace Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

[PublicAPI]
public class StateChangePayload
{
    public string EntityId { get; set; } = null!;
    public IEntityState? OldState { get; set; }
    public IEntityState NewState { get; set; } = null!;
}

[PublicAPI]
public class StateChangePayload<TState>
    where TState : class, IEntityState
{
    public string EntityId { get; set; } = null!;
    public TState? OldState { get; set; }
    public TState NewState { get; set; } = default!;
}
