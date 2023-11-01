using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantHttpConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddBinarySensor(this IHomeAssistantHttpClientConfigurationBuilder httpClientConfigurationBuilder)
    {
        return httpClientConfigurationBuilder.AddDomain<BinarySensorDomain, BinarySensorEntityStateDeserializer>();
    }
}
