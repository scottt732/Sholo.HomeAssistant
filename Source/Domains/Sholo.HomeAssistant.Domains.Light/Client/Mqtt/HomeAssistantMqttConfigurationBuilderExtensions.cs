using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddLight(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<ILightMqttEntityConfigurationBuilder, ILightMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

        ILightMqttEntityConfigurationBuilder builder = new LightMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddLight(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        ILightMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
