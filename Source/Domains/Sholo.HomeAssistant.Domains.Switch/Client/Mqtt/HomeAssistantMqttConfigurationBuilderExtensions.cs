using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddSwitch(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<ISwitchMqttEntityConfigurationBuilder, ISwitchMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

        ISwitchMqttEntityConfigurationBuilder builder = new SwitchMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddSwitch(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        ISwitchMqttEntityConfigurationBuilder mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
