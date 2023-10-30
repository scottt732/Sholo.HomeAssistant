using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface ICamera : IEntity
{
    Task SendAsync(string payload, CancellationToken cancellationToken = default);
}
