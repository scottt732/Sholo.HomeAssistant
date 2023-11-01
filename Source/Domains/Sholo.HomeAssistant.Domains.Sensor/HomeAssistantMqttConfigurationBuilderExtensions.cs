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
    public static IHomeAssistantMqttClientConfigurationBuilder AddSensor(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<ISensorMqttEntityConfigurationBuilder, ISensorMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<SensorDomain, ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

        ISensorMqttEntityConfigurationBuilder builder = new SensorMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddSensor(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        ISensorMqttEntityConfiguration mqttEntityConfigurationBuilder)
    {
        configurationBuilder.AddDomain<SensorDomain, ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
        return configurationBuilder;
    }
}
