using System;

namespace Sholo.HomeAssistant;

[PublicAPI]
public class HomeAssistantClientConfigurationBuilder : IHomeAssistantClientConfigurationBuilder
{
    public IHomeAssistantServiceCollection ServiceCollection { get; }

    public HomeAssistantClientConfigurationBuilder(IHomeAssistantServiceCollection serviceCollection)
    {
        ServiceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
    }
}
