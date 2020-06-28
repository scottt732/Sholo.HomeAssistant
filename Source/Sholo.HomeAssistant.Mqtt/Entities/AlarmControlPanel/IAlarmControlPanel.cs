using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel
{
    [PublicAPI]
    public interface IAlarmControlPanel : IStatefulEntity
    {
        Task Arm(string code = null, CancellationToken cancellationToken = default);
        Task Disarm(string code = null, CancellationToken cancellationToken = default);
        Task ArmAway(string code = null, CancellationToken cancellationToken = default);
        Task ArmHome(string code = null, CancellationToken cancellationToken = default);
        Task ArmNight(string code = null, CancellationToken cancellationToken = default);
    }
}
