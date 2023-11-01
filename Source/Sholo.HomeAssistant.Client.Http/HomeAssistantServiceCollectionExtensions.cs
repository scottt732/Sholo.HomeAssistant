using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Settings;
using Sholo.HomeAssistant.StateDeserializers;
using Sholo.HomeAssistant.Utilities.Validation;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public static class HomeAssistantServiceCollectionExtensions
{
    public static IHomeAssistantConfigurationBuilder WithHttpClient(this IHomeAssistantConfigurationBuilder configurationBuilder, Action<IHomeAssistantHttpClientConfigurationBuilder> builderConfigurator)
    {
        var clientConfiguration = configurationBuilder.Configuration.GetSection("client:http");

        configurationBuilder.Services.AddOptions<HomeAssistantClientOptions>()
            .Bind(clientConfiguration)
            .ValidateDataAnnotations(true)
            .ValidateOnStart();

        configurationBuilder.Services.AddSingleton<IStateProvider, StateProvider>();
        configurationBuilder.Services.AddSingleton<IStateCodeGenerator, NoOpStateCodeGenerator>();

        var httpClientConfigurationBuilder = new HomeAssistantHttpClientConfigurationBuilder(configurationBuilder);
        builderConfigurator.Invoke(httpClientConfigurationBuilder);

        return configurationBuilder;
    }
}
