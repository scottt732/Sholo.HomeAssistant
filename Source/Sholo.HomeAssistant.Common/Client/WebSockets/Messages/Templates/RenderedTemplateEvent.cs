using Sholo.HomeAssistant.Client.WebSockets.Events;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

[PublicAPI]
public class RenderedTemplateEvent : IEventMessage
{
    public int Id { get; init; }
    public string Result { get; init; } = null!;
    public EventListeners? Listeners { get; init; }
}
