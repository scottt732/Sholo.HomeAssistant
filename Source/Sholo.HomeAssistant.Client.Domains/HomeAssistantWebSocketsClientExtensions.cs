using System;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Domains.BinarySensor;
using Sholo.HomeAssistant.Client.Domains.Light;
using Sholo.HomeAssistant.Client.Domains.MediaPlayer;
using Sholo.HomeAssistant.Client.Domains.Sensor;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Events.StateChanged;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Domains
{
    [PublicAPI]
    public static class HomeAssistantWebSocketsClientExtensions
    {
        public static IAsyncEnumerable<EventMessage<StateChangePayload<BinarySensorEntityState>>> GetBinarySensorStateChangesAsync(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<StateChangePayload<BinarySensorEntityState>>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => client.GetStateChangesAsync(predicate, cancellationToken);

        public static IAsyncEnumerable<EventMessage<StateChangePayload<LightEntityState>>> GetLightStateChangesAsync(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<StateChangePayload<LightEntityState>>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => client.GetStateChangesAsync(predicate, cancellationToken);

        public static IAsyncEnumerable<EventMessage<StateChangePayload<MediaPlayerEntityState>>> GetMediaPlayerStateChangesAsync(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<StateChangePayload<MediaPlayerEntityState>>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => client.GetStateChangesAsync(predicate, cancellationToken);

        public static IAsyncEnumerable<EventMessage<StateChangePayload<SensorEntityState>>> GetSensorStateChangesAsync(
            this IHomeAssistantWebSocketsClient client,
            Func<EventMessage<StateChangePayload<SensorEntityState>>, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => client.GetStateChangesAsync(predicate, cancellationToken);
    }
}
