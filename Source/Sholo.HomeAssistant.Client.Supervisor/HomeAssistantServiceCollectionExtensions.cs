namespace Sholo.HomeAssistant.Client.Supervisor;

[PublicAPI]
public static class HomeAssistantServiceCollectionExtensions
{
    public static IHomeAssistantServiceCollection AddClient(this IHomeAssistantServiceCollection services, Action<IHomeAssistantClientConfigurationBuilder>? builderConfigurator = null)
    {
        return services;
    }
}
