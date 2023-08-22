using System;
using Sholo.HomeAssistant.DependencyInjection;

namespace Sholo.HomeAssistant.Mqtt
{
    public class HomeAssistantMqttConfigurationBuilder : IHomeAssistantMqttConfigurationBuilder
    {
        public IHomeAssistantServiceCollection ServiceCollection { get; }

        public HomeAssistantMqttConfigurationBuilder(IHomeAssistantServiceCollection homeAssistantServiceCollection)
        {
            ServiceCollection = homeAssistantServiceCollection ?? throw new ArgumentNullException(nameof(homeAssistantServiceCollection));
        }
    }
}
