using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantHttpConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddClimate(this IHomeAssistantHttpClientConfigurationBuilder httpClientConfigurationBuilder)
    {
        return httpClientConfigurationBuilder.AddDomain<ClimateDomain, ClimateEntityStateDeserializer>();
    }
}
