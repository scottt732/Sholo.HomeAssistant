using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface IFan : ICoreSwitchEntity
{
    Task TurnOffAsync(CancellationToken cancellationToken = default);
    Task TurnOnAsync(CancellationToken cancellationToken = default);
    Task SetSpeedAsync(FanSpeed fanSpeed, CancellationToken cancellationToken = default);
}
