using Sholo.HomeAssistant.Client.Shared.EntityStates;

namespace Sholo.HomeAssistant.Client.Http.Rest;

public class CreateOrUpdateStateResult<TState, TStateAttributes> : BaseCreateOrUpdateStateResult<TState>
    where TState : IEntityState<TStateAttributes>
{
    public CreateOrUpdateStateResult(CreateOrUpdateStateResultType stateAction, TState state, Uri? entityUri)
        : base(stateAction, state, entityUri)
    {
    }
}

public class CreateOrUpdateStateResult<TState, TStateValue, TStateAttributes> : BaseCreateOrUpdateStateResult<TState>
    where TState : IEntityState<TStateValue, TStateAttributes>
{
    public CreateOrUpdateStateResult(CreateOrUpdateStateResultType stateAction, TState state, Uri? entityUri)
        : base(stateAction, state, entityUri)
    {
    }
}
