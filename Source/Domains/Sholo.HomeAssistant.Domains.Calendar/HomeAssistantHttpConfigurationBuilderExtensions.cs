using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantHttpConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddCalendar(this IHomeAssistantHttpClientConfigurationBuilder httpConfigurationBuilder)
    {
        return httpConfigurationBuilder.AddDomain<CalendarDomain, CalendarEntityStateDeserializer>();
    }
}
