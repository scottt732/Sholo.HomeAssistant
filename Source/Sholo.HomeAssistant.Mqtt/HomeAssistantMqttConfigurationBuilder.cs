using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Mqtt
{
    public class HomeAssistantMqttConfigurationBuilder : IHomeAssistantMqttConfigurationBuilder
    {
        public IConfiguration HomeAssistantRootConfiguration { get; }
        public IConfiguration MqttRootConfiguration { get; }
        public IServiceCollection ServiceCollection { get; }

        public HomeAssistantMqttConfigurationBuilder(
            IConfiguration homeAssistantRootConfiguration,
            IServiceCollection serviceCollection,
            string configurationSectionName = "mqtt")
        {
            HomeAssistantRootConfiguration = homeAssistantRootConfiguration ?? throw new ArgumentNullException(nameof(homeAssistantRootConfiguration));
            MqttRootConfiguration = homeAssistantRootConfiguration.GetSection(configurationSectionName ?? throw new ArgumentNullException(nameof(configurationSectionName)));
            ServiceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }
    }
}
