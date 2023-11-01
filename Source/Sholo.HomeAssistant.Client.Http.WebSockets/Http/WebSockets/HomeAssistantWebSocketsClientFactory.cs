using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Http.WebSockets;

public class HomeAssistantWebSocketsClientFactory : IHomeAssistantWebSocketsClientFactory
{
    private IServiceProvider ServiceProvider { get; }

    public HomeAssistantWebSocketsClientFactory(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public IHomeAssistantWebSocketsClient CreateClient() => ServiceProvider.GetRequiredService<IHomeAssistantWebSocketsClient>();
}
