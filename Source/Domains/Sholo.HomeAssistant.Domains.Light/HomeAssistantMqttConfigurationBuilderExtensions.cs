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
    public static IHomeAssistantMqttClientConfigurationBuilder AddLight(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<ILightMqttEntityConfigurationBuilder, ILightMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<LightDomain, ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

        ILightMqttEntityConfigurationBuilder builder = new LightMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddLight(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        ILightMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddDomain<LightDomain, ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
