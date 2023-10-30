using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Client.WebSockets.BackgroundService;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
public static class HomeAssistantServiceCollectionExtensions
{
    public static IHomeAssistantServiceCollection AddClient(this IHomeAssistantServiceCollection services, Action<IHomeAssistantClientConfigurationBuilder>? builderConfigurator = null)
    {
        services.AddSingleton<IHomeAssistantWebSocketsConnectionService, HomeAssistantWebSocketsConnectionService>();
        services.AddSingleton<IHomeAssistantWebSocketsClientFactory, HomeAssistantWebSocketsClientFactory>();
        services.AddTransient<IHomeAssistantWebSocketsClient, HomeAssistantWebSocketsClient>();
        services.AddHostedService<HomeAssistantWebSocketsClientBackgroundService>();

        services.AddSingleton<IStateProvider, StateProvider>();
        services.AddSingleton<IStateCodeGenerator, NoOpStateCodeGenerator>();

        var configurationBuilder = new HomeAssistantClientConfigurationBuilder(services);
        builderConfigurator?.Invoke(configurationBuilder);

        return services;
    }
}
