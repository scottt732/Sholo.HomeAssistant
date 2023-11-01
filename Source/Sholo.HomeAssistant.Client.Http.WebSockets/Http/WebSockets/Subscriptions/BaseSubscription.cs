using System.Reactive.Linq;
using System.Reactive.Subjects;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Subscriptions;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.Subscriptions;

internal abstract class BaseSubscription<TSelf, TEventMessage> : ISubscription, IAsyncEnumerable<TEventMessage>
    where TSelf : BaseSubscription<TSelf, TEventMessage>
    where TEventMessage : IEventMessage
{
    public Guid LocalId { get; }
    public string? EventType { get; }

    public long? CurrentConnectionId { get; private set; }
    public long CurrentSubscriptionId { get; private set; }

    internal Func<long, long, CancellationToken, Task<UnsubscribeResult>> Unsubscriber { get; }
    internal ISubject<TEventMessage> SubscriptionEventStream { get; } = new Subject<TEventMessage>();

    private Func<IObservable<TEventMessage>, IObservable<TEventMessage>> EventFilter { get; }
    private Func<Stream, CancellationToken, Task<TEventMessage>> MessageParser { get; }

    protected BaseSubscription(
        Guid localId,
        string? eventType,
        long currentSubscriptionId,
        Func<IObservable<TEventMessage>, IObservable<TEventMessage>> eventFilter,
        Func<Stream, CancellationToken, Task<TEventMessage>> messageParser,
        Func<long, long, CancellationToken, Task<UnsubscribeResult>> unsubscriber)
    {
        LocalId = localId;
        EventType = eventType;
        CurrentSubscriptionId = currentSubscriptionId;
        EventFilter = eventFilter;
        MessageParser = messageParser;
        Unsubscriber = unsubscriber;
    }

    public void Bind(IObservable<IEventMessage> firehose, long connectionId, long subscriptionId, CancellationToken cancellationToken)
    {
        CurrentConnectionId = connectionId;
        CurrentSubscriptionId = subscriptionId;
        var filteredFirehose = EventFilter.Invoke(firehose.Where(x => x.Id == subscriptionId).OfType<TEventMessage>());
        filteredFirehose.Subscribe(SubscriptionEventStream.OnNext, () => { }, cancellationToken);
    }

    public async Task<IEventMessage> ParseMessageAsync(Stream stream, CancellationToken cancellationToken)
        => await MessageParser.Invoke(stream, cancellationToken);

    public IAsyncEnumerator<TEventMessage> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => new SubscriptionAsyncEnumerator<TSelf, TEventMessage>((TSelf)this, cancellationToken);

    public async ValueTask DisposeAsync()
    {
        if (CurrentConnectionId.HasValue)
        {
            await Unsubscriber.Invoke(CurrentConnectionId.Value, CurrentSubscriptionId, CancellationToken.None);
        }
    }
}
