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
    public static IHomeAssistantMqttClientConfigurationBuilder AddCover(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<ICoverMqttEntityConfigurationBuilder, ICoverMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddStatefulDomain<CoverDomain, ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

        ICoverMqttEntityConfigurationBuilder builder = new CoverMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddCover(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        ICoverMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddStatefulDomain<CoverDomain, ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
