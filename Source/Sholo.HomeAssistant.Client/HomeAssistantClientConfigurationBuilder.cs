using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Client
{
    [PublicAPI]
    public class HomeAssistantClientConfigurationBuilder : IHomeAssistantClientConfigurationBuilder
    {
        public IConfiguration HomeAssistantRootConfiguration { get; }
        public IConfiguration ClientRootConfiguration { get; }
        public IServiceCollection ServiceCollection { get; }

        public HomeAssistantClientConfigurationBuilder(
            IConfiguration homeAssistantRootConfiguration,
            IServiceCollection serviceCollection,
            string configurationSectionName = "client")
        {
            HomeAssistantRootConfiguration = homeAssistantRootConfiguration ?? throw new ArgumentNullException(nameof(homeAssistantRootConfiguration));
            ClientRootConfiguration = homeAssistantRootConfiguration.GetSection(configurationSectionName ?? throw new ArgumentNullException(nameof(configurationSectionName)));
            ServiceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }
    }
}
