using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttClientConfigurationBuilder AddDeviceTrigger(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTriggerMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<DeviceTriggerDomain, IDeviceTriggerMqttEntityConfiguration, IDeviceTrigger, IDeviceTriggerEntityDefinition>();

        IDeviceTriggerMqttEntityConfigurationBuilder builder = new DeviceTriggerMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddDeviceTrigger(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        IDeviceTriggerMqttEntityConfiguration mqttEntityConfigurationBuilder)
    {
        configurationBuilder.AddDomain<DeviceTriggerDomain, IDeviceTriggerMqttEntityConfiguration, IDeviceTrigger, IDeviceTriggerEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
        return configurationBuilder;
    }
}
