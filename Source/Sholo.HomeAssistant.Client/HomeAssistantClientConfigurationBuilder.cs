using System;
using JetBrains.Annotations;
using Sholo.HomeAssistant.DependencyInjection;

namespace Sholo.HomeAssistant.Client
{
    [PublicAPI]
    public class HomeAssistantClientConfigurationBuilder : IHomeAssistantClientConfigurationBuilder
    {
        public IHomeAssistantServiceCollection ServiceCollection { get; }

        public HomeAssistantClientConfigurationBuilder(IHomeAssistantServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }
    }
}
