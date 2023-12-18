namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

public interface IContextualizedResult
{
    public CommandContext CommandContext { get; }
}
