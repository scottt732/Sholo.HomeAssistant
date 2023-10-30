using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.Http.WebSockets;

[PublicAPI]
public static class HomeAssistantWebSocketsClientExtensions
{
    public static IAsyncEnumerable<IEventMessage<StateChangePayload<BinarySensorEntityState>>> GetBinarySensorStateChangesAsync(
        this IHomeAssistantWebSocketsClient client,
        Func<IEventMessage<StateChangePayload<BinarySensorEntityState>>, bool>? predicate = null,
        CancellationToken cancellationToken = default
    )
        => client.GetStateChangesAsync(predicate, cancellationToken);
}
