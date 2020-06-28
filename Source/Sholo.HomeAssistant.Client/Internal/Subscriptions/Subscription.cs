using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Messages.Subscriptions;

namespace Sholo.HomeAssistant.Client.Internal.Subscriptions
{
    internal class Subscription : BaseSubscription<Subscription, EventMessage>
    {
        public Subscription(
            Guid localId,
            string eventType,
            long currentSubscriptionId,
            Func<IObservable<EventMessage>, IObservable<EventMessage>> eventFilter,
            Func<Stream, CancellationToken, Task<EventMessage>> messageParser,
            Func<long, long, CancellationToken, Task<UnsubscribeResult>> unsubscriber
        )
            : base(
                localId,
                eventType,
                currentSubscriptionId,
                eventFilter,
                messageParser,
                unsubscriber
            )
        {
        }
    }

    internal class Subscription<TEventMessage> : BaseSubscription<Subscription<TEventMessage>, TEventMessage>
        where TEventMessage : IEventMessage
    {
        public Subscription(
            Guid localId,
            string eventType,
            long currentSubscriptionId,
            Func<IObservable<TEventMessage>, IObservable<TEventMessage>> eventFilter,
            Func<Stream, CancellationToken, Task<TEventMessage>> messageParser,
            Func<long, long, CancellationToken, Task<UnsubscribeResult>> unsubscriber
        )
            : base(
                localId,
                eventType,
                currentSubscriptionId,
                eventFilter,
                messageParser,
                unsubscriber
            )
        {
        }
    }
}
