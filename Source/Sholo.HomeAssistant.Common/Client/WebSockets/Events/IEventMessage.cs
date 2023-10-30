namespace Sholo.HomeAssistant.Client.WebSockets.Events;

public interface IEventMessage
{
    int Id { get; }
}

public interface IEventMessage<TPayload> : IEventMessage
{
    EventData<TPayload> Event { get; }
}
