using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.Entities.Fan;

namespace Sholo.HomeAssistant.Mqtt.Entities.Vacuum
{
    [PublicAPI]
    public interface IVacuum : IStatefulEntity
    {
        Task SetSpeed(FanSpeed fanSpeed, CancellationToken cancellationToken = default);
        Task CleanSpot(CancellationToken cancellationToken = default);
        Task Locate(CancellationToken cancellationToken = default);
        Task Pause(CancellationToken cancellationToken = default);
        Task ReturnToBase(CancellationToken cancellationToken = default);
        Task Start(CancellationToken cancellationToken = default);
        Task Stop(CancellationToken cancellationToken = default);
        Task SetFanSpeed(CancellationToken cancellationToken = default);
    }
}
