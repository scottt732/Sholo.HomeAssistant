using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.Light
{
    [PublicAPI]
    public interface ILight : ICoreSwitchEntity
    {
        Task SetBrightness(int brightness, CancellationToken cancellationToken = default);
        Task SetColorTemperature(string colorTemperature, CancellationToken cancellationToken = default);
        Task SetEffect(string effect, CancellationToken cancellationToken = default);
        Task SetHueSaturation(string hs, CancellationToken cancellationToken = default);
        Task TurnOn(CancellationToken cancellationToken = default);
        Task TurnOff(CancellationToken cancellationToken = default);
        Task SetRgb(string rgb, CancellationToken cancellationToken = default);
        Task SetWhiteValue(string whiteValue, CancellationToken cancellationToken = default);
        Task SetXy(string xy, CancellationToken cancellationToken = default);
    }
}
