using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface ILight : ICoreSwitchEntity
{
    Task SetBrightnessAsync(int brightness, CancellationToken cancellationToken = default);
    Task SetColorTemperatureAsync(string colorTemperature, CancellationToken cancellationToken = default);
    Task SetEffectAsync(string effect, CancellationToken cancellationToken = default);
    Task SetHueSaturationAsync(string hs, CancellationToken cancellationToken = default);
    Task TurnOnAsync(CancellationToken cancellationToken = default);
    Task TurnOffAsync(CancellationToken cancellationToken = default);
    Task SetRgbAsync(string rgb, CancellationToken cancellationToken = default);
    Task SetWhiteValueAsync(string whiteValue, CancellationToken cancellationToken = default);
    Task SetXyAsync(string xy, CancellationToken cancellationToken = default);
}
