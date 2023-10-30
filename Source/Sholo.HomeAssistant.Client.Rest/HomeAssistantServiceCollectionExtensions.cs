using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Settings;
using Sholo.HomeAssistant.StateDeserializers;
using Sholo.HomeAssistant.Utilities.Validation;

namespace Sholo.HomeAssistant.Client.Rest;

[PublicAPI]
public static class HomeAssistantServiceCollectionExtensions
{
    public static IHomeAssistantServiceCollection AddClient(this IHomeAssistantServiceCollection services, Action<IHomeAssistantClientConfigurationBuilder>? builderConfigurator = null)
    {
        services.AddOptions<HomeAssistantClientOptions>()
            .Bind(services.Configuration.GetSection("client"))
            .ValidateDataAnnotations(true)
            .ValidateOnStart();

        services.AddHttpClient<IHomeAssistantRestClient, HomeAssistantRestClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<HomeAssistantClientOptions>>();
            client.BaseAddress = options.Value.RestApiUrlPrefix;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.Value.Auth.Token);
        });

        services.AddSingleton<IStateProvider, StateProvider>();
        services.AddSingleton<IStateCodeGenerator, NoOpStateCodeGenerator>();

        var configurationBuilder = new HomeAssistantClientConfigurationBuilder(services);
        builderConfigurator?.Invoke(configurationBuilder);

        return services;
    }
}
