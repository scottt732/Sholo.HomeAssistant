using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddDeviceTrigger(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTriggerMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<IDeviceTriggerMqttEntityConfiguration, IDeviceTrigger, IDeviceTriggerEntityDefinition>();

        IDeviceTriggerMqttEntityConfigurationBuilder builder = new DeviceTriggerMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddDeviceTrigger(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        IDeviceTriggerMqttEntityConfiguration mqttEntityConfigurationBuilder)
    {
        configurationBuilder.TryRegisterEntityBindingManager<IDeviceTriggerMqttEntityConfiguration, IDeviceTrigger, IDeviceTriggerEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
        return configurationBuilder;
    }
}
