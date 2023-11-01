using Sholo.HomeAssistant.Client.WebSockets.Events;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.Subscriptions;

[PublicAPI]
internal interface ISubscription : IAsyncDisposable
{
    Guid LocalId { get; }
    string? EventType { get; }
    long? CurrentConnectionId { get; }
    long CurrentSubscriptionId { get; }
    void Bind(IObservable<IEventMessage> firehose, long connectionId, long subscriptionId, CancellationToken cancellationToken);
    Task<IEventMessage> ParseMessageAsync(Stream stream, CancellationToken cancellationToken);
}
