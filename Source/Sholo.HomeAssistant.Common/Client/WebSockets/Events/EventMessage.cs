using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.WebSockets.Events;

[PublicAPI]
public class EventMessage : BaseResultMessage, IEventMessage
{
    public int Id { get; set; }

    protected EventMessage()
        : base(HomeAssistantWsMessageType.Event)
    {
    }
}

[PublicAPI]
public class EventMessage<TPayload> : EventMessage, IEventMessage<TPayload>
{
    public EventData<TPayload> Event { get; set; } = null!;
}
