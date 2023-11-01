using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantHttpConfigurationBuilderExtensions
{
    public static IHomeAssistantHttpClientConfigurationBuilder AddAlarmControlPanel(this IHomeAssistantHttpClientConfigurationBuilder builder)
        => builder.AddDomain<AlarmControlPanelDomain, AlarmControlPanelEntityStateDeserializer>();
}
