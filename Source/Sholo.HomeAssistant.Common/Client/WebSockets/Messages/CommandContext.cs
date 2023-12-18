namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

public class CommandContext
{
    public string Id { get; init; } = null!;
    public string? ParentId { get; init; }
    public string? UserId { get; init; }
}
