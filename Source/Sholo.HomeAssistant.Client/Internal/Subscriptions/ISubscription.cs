using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Events;

namespace Sholo.HomeAssistant.Client.Internal.Subscriptions
{
    [PublicAPI]
    internal interface ISubscription : IAsyncDisposable
    {
        Guid LocalId { get; }
        string EventType { get; }
        long? CurrentConnectionId { get; }
        long CurrentSubscriptionId { get; }
        void Bind(IObservable<IEventMessage> firehose, long connectionId, long subscriptionId, CancellationToken cancellationToken);
        Task<IEventMessage> ParseMessage(Stream stream, CancellationToken cancellationToken);
    }
}
