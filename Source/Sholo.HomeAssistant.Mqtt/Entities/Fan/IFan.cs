using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.Fan
{
    [PublicAPI]
    public interface IFan : ICoreSwitchEntity
    {
        Task TurnOff(CancellationToken cancellationToken = default);
        Task TurnOn(CancellationToken cancellationToken = default);
        Task SetSpeed(FanSpeed fanSpeed, CancellationToken cancellationToken = default);
    }
}
