using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.Cover
{
    [PublicAPI]
    public interface ICover : ICoreSwitchEntity
    {
        Task Close(CancellationToken cancellationToken = default);
        Task Open(CancellationToken cancellationToken = default);
        Task Stop(CancellationToken cancellationToken = default);
        Task SetPosition(float position, CancellationToken cancellationToken = default);
    }
}
