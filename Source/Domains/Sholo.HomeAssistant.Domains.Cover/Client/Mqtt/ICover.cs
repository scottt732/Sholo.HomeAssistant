using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface ICover : ICoreSwitchEntity
{
    Task CloseAsync(CancellationToken cancellationToken = default);
    Task OpenAsync(CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
    Task SetPositionAsync(float position, CancellationToken cancellationToken = default);
}
