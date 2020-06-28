using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.Camera
{
    [PublicAPI]
    public interface ICamera : IEntity
    {
        Task Send(string payload, CancellationToken cancellationToken = default);
    }
}
