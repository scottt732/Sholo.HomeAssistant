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
    public static IHomeAssistantMqttClientConfigurationBuilder AddBinarySensor(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<IBinarySensorMqttEntityConfigurationBuilder, IBinarySensorMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddStatefulDomain<BinarySensorDomain, IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

        IBinarySensorMqttEntityConfigurationBuilder builder = new BinarySensorMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddBinarySensor(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        IBinarySensorMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddStatefulDomain<BinarySensorDomain, IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
