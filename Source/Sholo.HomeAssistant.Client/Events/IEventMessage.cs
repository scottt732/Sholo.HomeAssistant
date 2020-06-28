namespace Sholo.HomeAssistant.Client.Events
{
    public interface IEventMessage
    {
        int Id { get; }
    }

#pragma warning disable CA1716
    public interface IEventMessage<TPayload> : IEventMessage
    {
        EventData<TPayload> Event { get; }
    }
#pragma warning restore CA1716
}
