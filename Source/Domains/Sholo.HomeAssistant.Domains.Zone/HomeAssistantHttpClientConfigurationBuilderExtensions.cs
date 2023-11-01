using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantHttpClientConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddZone(this IHomeAssistantHttpClientConfigurationBuilder httpClientConfigurationBuilder)
    {
        return httpClientConfigurationBuilder.AddDomain<ZoneDomain, ZoneEntityStateDeserializer>();
    }
}
