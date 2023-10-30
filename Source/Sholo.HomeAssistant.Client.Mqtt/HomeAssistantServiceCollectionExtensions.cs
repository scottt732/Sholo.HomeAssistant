using System;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.Discovery;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.HomeAssistant.Client.Mqtt.MqttNet;
using Sholo.HomeAssistant.Client.Mqtt.Services;
using Sholo.HomeAssistant.Utilities.Validation;
using Sholo.Mqtt.Application.BuilderConfiguration;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantServiceCollectionExtensions
{
    public static IHomeAssistantServiceCollection AddMqtt(
        this IHomeAssistantServiceCollection services,
        Action<IHomeAssistantMqttConfigurationBuilder> builderConfigurator = null)
    {
        services.AddOptions<HomeAssistantDiscoveryClientSettings>()
            .Bind(services.Configuration.GetSection("mqtt"))
            .ValidateDataAnnotations(true)
            .ValidateOnStart();

        services.AddSingleton<IMqttMessageBus, MqttMessageBus>();

        services.AddSingleton<IMqttEntityControlPanelHost, MqttEntityControlPanel>();
        services.AddSingleton<IMqttEntityControlPanel>(sp => sp.GetRequiredService<IMqttEntityControlPanelHost>());
        services.AddSingleton<IConfigureMqttApplicationBuilder>(sp => (MqttEntityControlPanel)sp.GetRequiredService<IMqttEntityControlPanel>());

        services.AddHostedService<HomeAssistantOutboundMqttDispatcher>();

        var configurationBuilder = new HomeAssistantMqttConfigurationBuilder(services);
        builderConfigurator?.Invoke(configurationBuilder);

        return services;
    }
}
