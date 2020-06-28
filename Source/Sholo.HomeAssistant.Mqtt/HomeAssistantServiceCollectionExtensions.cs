using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.DependencyInjection;
using Sholo.HomeAssistant.Mqtt.Dispatchers;
using Sholo.Mqtt.Consumer;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public static class HomeAssistantServiceCollectionExtensions
    {
        public static IHomeAssistantServiceCollection AddMqtt(
            this IHomeAssistantServiceCollection services,
            Action<IHomeAssistantMqttConfigurationBuilder> builderConfigurator = null)
        {
            services.AddSingleton<IOutboundMqttMessageBus, OutboundMqttMessageBus>();
            services.AddSingleton<IOutboundMqttMessageBusPublisher>(sp => sp.GetRequiredService<IOutboundMqttMessageBus>());
            services.AddSingleton<IOutboundMqttMessageBusConsumer>(sp => sp.GetRequiredService<IOutboundMqttMessageBus>());

            services.AddSingleton<IMqttEntityControlPanel, MqttEntityControlPanel>();
            services.AddHostedService<HomeAssistantOutboundMqttDispatcher>();

            services.AddTransient<IConfigureMqttApplicationBuilder, HomeAssistantIncomingMqttDispatcher>();

            var configurationBuilder = new HomeAssistantMqttConfigurationBuilder(services.Configuration, services);
            builderConfigurator?.Invoke(configurationBuilder);

            return services;
        }
    }
}
