using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.DependencyInjection;
using Sholo.HomeAssistant.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Mqtt.Dispatchers;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.Mqtt.ApplicationBuilderConfiguration;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public static class HomeAssistantServiceCollectionExtensions
    {
        public static IHomeAssistantServiceCollection AddMqtt(
            this IHomeAssistantServiceCollection services,
            Action<IHomeAssistantMqttConfigurationBuilder> builderConfigurator = null)
        {
            services.AddSingleton<IMqttMessageBus, MqttMessageBus>();

            services.AddSingleton<IMqttEntityControlPanel, MqttEntityControlPanel>();
            services.AddSingleton<IConfigureMqttApplicationBuilder>(sp => sp.GetRequiredService<IMqttEntityControlPanel>());

            services.AddHostedService<HomeAssistantOutboundMqttDispatcher>();

            var configurationBuilder = new HomeAssistantMqttConfigurationBuilder(services.Configuration, services);
            builderConfigurator?.Invoke(configurationBuilder);

            return services;
        }
    }
}
