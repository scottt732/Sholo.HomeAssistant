using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Events;

namespace Sholo.HomeAssistant.Client.Internal.Subscriptions
{
    internal class SubscriptionAsyncEnumerator<TSubscription, TEventMessage> : IAsyncEnumerator<TEventMessage>
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
}
