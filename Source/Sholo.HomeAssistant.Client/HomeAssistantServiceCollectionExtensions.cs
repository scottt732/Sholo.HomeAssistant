using System;
using System.Net.Http.Headers;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sholo.HomeAssistant.Client.Rest;
using Sholo.HomeAssistant.Client.Settings;
using Sholo.HomeAssistant.Client.StateDeserializers;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.BackgroundService;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;
using Sholo.HomeAssistant.DependencyInjection;

namespace Sholo.HomeAssistant.Client
{
    [PublicAPI]
    public static class HomeAssistantServiceCollectionExtensions
    {
        public static IHomeAssistantServiceCollection AddClient(this IHomeAssistantServiceCollection services, Action<IHomeAssistantClientConfigurationBuilder> builderConfigurator = null)
        {
            services.AddOptions<HomeAssistantClientOptions>().Bind(services.Configuration.GetSection("client"));

            services.AddHttpClient<IHomeAssistantRestClient, HomeAssistantRestClient>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<HomeAssistantClientOptions>>();
                client.BaseAddress = options.Value.RestApiUrlPrefix;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.Value.Auth.Token);
            });

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
}
