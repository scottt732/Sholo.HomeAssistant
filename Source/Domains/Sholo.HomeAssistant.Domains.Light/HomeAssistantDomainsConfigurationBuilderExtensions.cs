using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantDomainsConfigurationBuilderExtensions
{
    public static IHomeAssistantDomainsConfigurationBuilder AddLight(this IHomeAssistantDomainsConfigurationBuilder domainsConfigurationBuilder)
    {
        return domainsConfigurationBuilder.AddDomain<LightEntityStateDeserializer>();
    }
}