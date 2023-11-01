namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public static class HomeAssistantConfigurationBuilderExtensions
{
    public static IHomeAssistantConfigurationBuilder AddSupervisorClient(this IHomeAssistantConfigurationBuilder configurationBuilder, Action<IHomeAssistantSupervisorClientConfigurationBuilder>? builderConfigurator = null)
    {
        return configurationBuilder;
    }
}
