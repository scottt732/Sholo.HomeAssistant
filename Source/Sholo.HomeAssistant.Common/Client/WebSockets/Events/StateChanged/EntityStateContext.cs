namespace Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

[PublicAPI]
public class EntityStateContext : IEntityStateContext
{
    public string Id { get; set; } = null!;
    public string? ParentId { get; set; } = null!;
    public string? UserId { get; set; } = null!;
}
