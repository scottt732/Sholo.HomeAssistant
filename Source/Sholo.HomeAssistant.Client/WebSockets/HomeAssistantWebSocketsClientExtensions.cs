using System;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Events.StateChanged;
using Sholo.HomeAssistant.Client.Events.TimeChanged;

namespace Sholo.HomeAssistant.Client.WebSockets
{
    [PublicAPI]
    public static class HomeAssistantWebSocketsClientExtensions
    {
        public static IAsyncEnumerable<EventMessage<StateChangePayload>> GetStateChangesAsync(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<StateChangePayload>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => client.Subscribe(EventTypes.Instance.StateChanged(), predicate, cancellationToken);

        public static IAsyncEnumerable<EventMessage<StateChangePayload<TState>>> GetStateChangesAsync<TState>(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<StateChangePayload<TState>>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            where TState : EntityState
                => client.Subscribe(EventTypes.Instance.StateChanged(), predicate, cancellationToken);

        // TODO: Broken?
        public static IAsyncEnumerable<EventMessage<TimeChangedPayload>> GetTimeChangesAsync(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<TimeChangedPayload>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => client.Subscribe(EventTypes.Instance.TimeChanged(), predicate, cancellationToken);

        // See HomeAssistantWebSocketsClientExtensions.cs in Sholo.HomeAssistant.Client.Domains
    }
}
