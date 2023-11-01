using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Http.WebSockets;
using Sholo.HomeAssistant.Client.Http.WebSockets.BackgroundService;
using Sholo.HomeAssistant.Client.Http.WebSockets.ConnectionService;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public static class HomeAssistantHttpClientConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddWebSocketApiClient(this IHomeAssistantHttpClientConfigurationBuilder configuration)
    {
        configuration.ServiceCollection.AddSingleton<IHomeAssistantWebSocketsConnectionService, HomeAssistantWebSocketsConnectionService>();
        configuration.ServiceCollection.AddSingleton<IHomeAssistantWebSocketsClientFactory, HomeAssistantWebSocketsClientFactory>();
        configuration.ServiceCollection.AddTransient<IHomeAssistantWebSocketsClient, HomeAssistantWebSocketsClient>();
        configuration.ServiceCollection.AddHostedService<HomeAssistantWebSocketsClientBackgroundService>();

        configuration.ServiceCollection.AddSingleton<IStateProvider, StateProvider>();
        configuration.ServiceCollection.AddSingleton<IStateCodeGenerator, NoOpStateCodeGenerator>();

        return configuration;
    }
}
