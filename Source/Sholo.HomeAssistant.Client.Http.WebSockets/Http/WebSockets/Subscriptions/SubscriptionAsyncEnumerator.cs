using System.Diagnostics;
using Sholo.HomeAssistant.Client.WebSockets.Events;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.Subscriptions;

internal sealed class SubscriptionAsyncEnumerator<TSubscription, TEventMessage> : IAsyncEnumerator<TEventMessage>
    where TSubscription : BaseSubscription<TSubscription, TEventMessage>
    where TEventMessage : IEventMessage
{
    private TSubscription Subscription { get; }
    private IAsyncEnumerator<TEventMessage> Enumerator { get; }

    public SubscriptionAsyncEnumerator(
        TSubscription subscription,
        CancellationToken cancellationToken
    )
    {
        if (!subscription.CurrentConnectionId.HasValue)
        {
            throw new ArgumentException($"The {nameof(subscription)} must have a {nameof(subscription.CurrentConnectionId)}", nameof(subscription));
        }

        Subscription = subscription;
        var enumerable = Subscription.SubscriptionEventStream.ToAsyncEnumerable();
        Enumerator = enumerable.GetAsyncEnumerator(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await Enumerator.DisposeAsync();

        Debug.Assert(Subscription.CurrentConnectionId != null, "Subscription.CurrentConnectionId != null");
        await Subscription.Unsubscriber(Subscription.CurrentConnectionId.Value, Subscription.CurrentSubscriptionId, CancellationToken.None);
    }

    public ValueTask<bool> MoveNextAsync() => Enumerator.MoveNextAsync();
    public TEventMessage Current => Enumerator.Current;
}
