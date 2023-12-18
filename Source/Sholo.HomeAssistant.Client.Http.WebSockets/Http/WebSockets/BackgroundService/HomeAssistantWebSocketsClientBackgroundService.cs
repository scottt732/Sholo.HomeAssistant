using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.BackgroundService;

public class HomeAssistantWebSocketsClientBackgroundService : Microsoft.Extensions.Hosting.BackgroundService
{
    private IHomeAssistantWebSocketsConnectionService ConnectionService { get; }

    public HomeAssistantWebSocketsClientBackgroundService(
        IHomeAssistantWebSocketsConnectionService connectionService)
    {
        ConnectionService = connectionService;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken) => ConnectionService.RunAsync(stoppingToken);
}
