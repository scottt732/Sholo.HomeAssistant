using Sholo.HomeAssistant.Exceptions;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

[PublicAPI]
public abstract class BaseCommandResult : BaseResultMessage
{
    public long Id { get; init; }
    public bool Success { get; init; }
    public CommandError? Error { get; init; }

    public void EnsureSuccessResult()
    {
        if (!Success)
        {
            if (Error != null)
            {
                throw new HomeAssistantCommandException(
                    Error.Message,
                    Error.Code,
                    Error.TranslationKey,
                    Error.TranslationDomain,
                    Error.TranslationPlaceholders
                );
            }

            throw new HomeAssistantCommandException();
        }
    }

    protected BaseCommandResult(params HomeAssistantWsMessageType[] validMessageTypes)
        : base(validMessageTypes)
    {
    }
}

[PublicAPI]
public abstract class BaseCommandResult<TResult> : BaseCommandResult
{
    public TResult? Result { get; init; }

    protected BaseCommandResult(params HomeAssistantWsMessageType[] validMessageTypes)
        : base(validMessageTypes)
    {
    }
}
