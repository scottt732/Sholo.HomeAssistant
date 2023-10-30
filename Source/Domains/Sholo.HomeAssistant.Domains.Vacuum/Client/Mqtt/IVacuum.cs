using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface IVacuum : IStatefulEntity
{
    Task SetSpeedAsync(VacuumFanSpeed fanSpeed, CancellationToken cancellationToken = default);
    Task CleanSpotAsync(CancellationToken cancellationToken = default);
    Task LocateAsync(CancellationToken cancellationToken = default);
    Task PauseAsync(CancellationToken cancellationToken = default);
    Task ReturnToBaseAsync(CancellationToken cancellationToken = default);
    Task StartAsync(CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
    Task SetFanSpeedAsync(CancellationToken cancellationToken = default);
}
