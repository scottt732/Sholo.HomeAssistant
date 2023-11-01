using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sholo.HomeAssistant.Client.Http.Rest;
using Sholo.HomeAssistant.Settings;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public static class HomeAssistantHttpClientConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddRestApiClient(this IHomeAssistantHttpClientConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ServiceCollection.AddHttpClient<IHomeAssistantRestClient, HomeAssistantRestClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<HomeAssistantClientOptions>>();
            client.BaseAddress = options.Value.RestApiUrlPrefix;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.Value.Auth.Token);
        });

        return configurationBuilder;
    }
}
