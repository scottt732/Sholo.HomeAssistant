using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Events.StateChanged
{
    [PublicAPI]
    public class StateChangePayload
    {
        public string EntityId { get; set; }
        public EntityState OldState { get; set; }
        public EntityState NewState { get; set; }
    }

    [PublicAPI]
    public class StateChangePayload<TState>
        where TState : EntityState
    {
        public string EntityId { get; set; }
        public TState OldState { get; set; }
        public TState NewState { get; set; }
    }
}
