using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantDomainsConfigurationBuilderExtensions
{
    public static IHomeAssistantDomainsConfigurationBuilder AddCamera(this IHomeAssistantDomainsConfigurationBuilder domainsConfigurationBuilder)
    {
        return domainsConfigurationBuilder.AddDomain<CameraEntityStateDeserializer>();
    }
}
