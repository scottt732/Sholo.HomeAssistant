using System;
using Sholo.HomeAssistant.Client.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.Rest
{
    public class CreateOrUpdateStateResult<TState, TStateAttributes> : BaseCreateOrUpdateStateResult<TState>
        where TState : EntityState<TStateAttributes>
    {
        public CreateOrUpdateStateResult(CreateOrUpdateStateResultType stateAction, TState state, Uri entityUri)
            : base(stateAction, state, entityUri)
        {
        }
    }

    public class CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes> : BaseCreateOrUpdateStateResult<TState>
        where TState : EntityState<TStateValue, TStateAttributes>
    {
        public CreateOrUpdateStateResult(CreateOrUpdateStateResultType stateAction, TState state, Uri entityUri)
            : base(stateAction, state, entityUri)
        {
        }
    }
}
