using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddCover(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<ICoverMqttEntityConfigurationBuilder, ICoverMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterStatefulEntityBindingManager<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

        ICoverMqttEntityConfigurationBuilder builder = new CoverMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddCover(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        ICoverMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterStatefulEntityBindingManager<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
