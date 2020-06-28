using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client.WebSockets
{
    public class HomeAssistantWebSocketsClientFactory : IHomeAssistantWebSocketsClientFactory
    {
        private IServiceProvider ServiceProvider { get; }

        public HomeAssistantWebSocketsClientFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IHomeAssistantWebSocketsClient CreateClient() => ServiceProvider.GetRequiredService<IHomeAssistantWebSocketsClient>();
    }
}
