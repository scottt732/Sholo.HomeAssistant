namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

[PublicAPI]
public abstract class BaseContextualizedCommandResult<TResult> : BaseCommandResult
    where TResult : IContextualizedResult
{
    public TResult? Result { get; init; }

    protected BaseContextualizedCommandResult(params HomeAssistantWsMessageType[] validMessageTypes)
        : base(validMessageTypes)
    {
    }
}
