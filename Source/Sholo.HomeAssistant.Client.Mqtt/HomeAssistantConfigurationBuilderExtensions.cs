using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Client.Mqtt.Discovery;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.HomeAssistant.Client.Mqtt.MqttNet;
using Sholo.HomeAssistant.Client.Mqtt.Services;
using Sholo.Mqtt.Application.BuilderConfiguration;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public static class HomeAssistantConfigurationBuilderExtensions
{
    public static IHomeAssistantConfigurationBuilder WithMqttClient(
        this IHomeAssistantConfigurationBuilder configurationBuilder,
        Action<IHomeAssistantMqttClientConfigurationBuilder> builderConfigurator = null)
    {
        configurationBuilder.Services.AddOptions<HomeAssistantDiscoveryClientSettings>()
            .Bind(configurationBuilder.Configuration.GetSection("client:mqtt"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        configurationBuilder.Services.AddSingleton<IMqttMessageBus, MqttMessageBus>();

        configurationBuilder.Services.AddSingleton<IMqttEntityControlPanelHost, MqttEntityControlPanel>();
        configurationBuilder.Services.AddSingleton<IMqttEntityControlPanel>(sp => sp.GetRequiredService<IMqttEntityControlPanelHost>());
        configurationBuilder.Services.AddSingleton<IConfigureMqttApplicationBuilder>(sp => (MqttEntityControlPanel)sp.GetRequiredService<IMqttEntityControlPanel>());

        configurationBuilder.Services.AddHostedService<HomeAssistantOutboundMqttDispatcher>();

        configurationBuilder.Services.AddSingleton<IEnumerable<IEntityBindingManager>>(sp =>
        {
            var entityBindingManagers = new List<IEntityBindingManager>();

            var entityBindingManagerConfigurations = sp.GetRequiredService<IEnumerable<IMqttEntityBindingManagerConfiguration>>();
            foreach (var configuration in entityBindingManagerConfigurations)
            {
                entityBindingManagers.Add(configuration.CreateBindingManager(sp));
            }

            var statefulEntityBindingManagerConfigurations = sp.GetRequiredService<IEnumerable<IMqttStatefulEntityBindingManagerConfiguration>>();
            foreach (var configuration in statefulEntityBindingManagerConfigurations)
            {
                entityBindingManagers.Add(configuration.CreateBindingManager(sp));
            }

            return entityBindingManagers;
        });

        var mqttClientConfigurationBuilder = new HomeAssistantMqttClientConfigurationBuilder(configurationBuilder);
        builderConfigurator?.Invoke(mqttClientConfigurationBuilder);

        return configurationBuilder;
    }
}
