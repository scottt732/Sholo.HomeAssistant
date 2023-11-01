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
    public static IHomeAssistantMqttClientConfigurationBuilder AddCamera(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<ICameraMqttEntityConfigurationBuilder, ICameraMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<CameraDomain, ICameraMqttEntityConfiguration, ICamera, ICameraEntityDefinition>();

        ICameraMqttEntityConfigurationBuilder builder = new CameraMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddCamera(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        ICameraMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddDomain<CameraDomain, ICameraMqttEntityConfiguration, ICamera, ICameraEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
