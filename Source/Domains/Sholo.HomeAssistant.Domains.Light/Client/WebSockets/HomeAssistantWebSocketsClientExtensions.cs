using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
public static class HomeAssistantWebSocketsClientExtensions
{
    public static IAsyncEnumerable<IEventMessage<StateChangePayload<LightEntityState>>> GetLightStateChangesAsync(
        this IHomeAssistantWebSocketsClient client,
        Func<IEventMessage<StateChangePayload<LightEntityState>>, bool>? predicate = null,
        CancellationToken cancellationToken = default
    )
        => client.GetStateChangesAsync(predicate, cancellationToken);
}
