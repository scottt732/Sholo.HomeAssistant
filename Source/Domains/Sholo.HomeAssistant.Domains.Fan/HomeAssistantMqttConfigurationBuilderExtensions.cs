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
    public static IHomeAssistantMqttClientConfigurationBuilder AddFan(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<IFanMqttEntityConfigurationBuilder, IFanMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<FanDomain, IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

        IFanMqttEntityConfigurationBuilder builder = new FanMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddFan(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        IFanMqttEntityConfiguration mqttEntityConfigurationBuilder)
    {
        configurationBuilder.AddDomain<FanDomain, IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
        return configurationBuilder;
    }
}
