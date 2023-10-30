using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface IAlarmControlPanel : IStatefulEntity
{
    Task ArmAsync(string? code = null, CancellationToken cancellationToken = default);
    Task DisarmAsync(string? code = null, CancellationToken cancellationToken = default);
    Task ArmAwayAsync(string? code = null, CancellationToken cancellationToken = default);
    Task ArmHomeAsync(string? code = null, CancellationToken cancellationToken = default);
    Task ArmNightAsync(string? code = null, CancellationToken cancellationToken = default);
}
