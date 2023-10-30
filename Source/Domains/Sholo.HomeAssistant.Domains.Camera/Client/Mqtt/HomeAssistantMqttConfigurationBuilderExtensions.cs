using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddCamera(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<ICameraMqttEntityConfigurationBuilder, ICameraMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ICameraMqttEntityConfiguration, ICamera, ICameraEntityDefinition>();

        ICameraMqttEntityConfigurationBuilder builder = new CameraMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddCamera(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        ICameraMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ICameraMqttEntityConfiguration, ICamera, ICameraEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
