using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddFan(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<IFanMqttEntityConfigurationBuilder, IFanMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

        IFanMqttEntityConfigurationBuilder builder = new FanMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddFan(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        IFanMqttEntityConfiguration mqttEntityConfigurationBuilder)
    {
        configurationBuilder.TryRegisterEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
        return configurationBuilder;
    }
}
