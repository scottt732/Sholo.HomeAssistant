using System;
using System.Collections.Generic;
using System.Threading;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;
using Sholo.HomeAssistant.Client.WebSockets.Events.TimeChanged;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
public static class HomeAssistantWebSocketsClientExtensions
{
    public static IAsyncEnumerable<IEventMessage<StateChangePayload>> GetStateChangesAsync(
        this IHomeAssistantWebSocketsClient client,
        Func<IEventMessage<StateChangePayload>, bool>? predicate = null,
        CancellationToken cancellationToken = default
    )
        => client.SubscribeAsync(EventTypes.Instance.StateChanged(), predicate, cancellationToken);

    public static IAsyncEnumerable<IEventMessage<StateChangePayload<TState>>> GetStateChangesAsync<TState>(
        this IHomeAssistantWebSocketsClient client,
        Func<IEventMessage<StateChangePayload<TState>>, bool>? predicate = null,
        CancellationToken cancellationToken = default
    )
        where TState : EntityState
        => client.SubscribeAsync(EventTypes.Instance.StateChanged(), predicate, cancellationToken);

    // TODO: Broken?
    public static IAsyncEnumerable<IEventMessage<TimeChangedPayload>> GetTimeChangesAsync(
        this IHomeAssistantWebSocketsClient client,
        Func<IEventMessage<TimeChangedPayload>, bool>? predicate = null,
        CancellationToken cancellationToken = default
    )
        => client.SubscribeAsync(EventTypes.Instance.TimeChanged(), predicate, cancellationToken);

    // See HomeAssistantWebSocketsClientExtensions.cs in Sholo.HomeAssistant.Client.Domains
}
