using Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantDomainsConfigurationBuilderExtensions
{
    public static IHomeAssistantDomainsConfigurationBuilder AddAlarmControlPanel(this IHomeAssistantDomainsConfigurationBuilder builder)
        => builder.AddDomain<AlarmControlPanelEntityStateDeserializer>();
}
