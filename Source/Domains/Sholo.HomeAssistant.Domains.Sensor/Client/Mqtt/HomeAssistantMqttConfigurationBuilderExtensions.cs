using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddSensor(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<ISensorMqttEntityConfigurationBuilder, ISensorMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

        ISensorMqttEntityConfigurationBuilder builder = new SensorMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddSensor(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        ISensorMqttEntityConfiguration mqttEntityConfigurationBuilder)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
        return configurationBuilder;
    }
}
