namespace Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

[PublicAPI]
public interface IEntityStateContext
{
    string Id { get; }
    string? ParentId { get; }
    string? UserId { get; }
}
