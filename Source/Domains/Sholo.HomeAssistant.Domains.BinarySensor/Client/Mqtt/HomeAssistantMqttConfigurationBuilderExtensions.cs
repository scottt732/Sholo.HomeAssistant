using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddBinarySensor(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<IBinarySensorMqttEntityConfigurationBuilder, IBinarySensorMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterStatefulEntityBindingManager<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

        IBinarySensorMqttEntityConfigurationBuilder builder = new BinarySensorMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddBinarySensor(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        IBinarySensorMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterStatefulEntityBindingManager<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
