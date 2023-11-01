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
    public static IHomeAssistantMqttClientConfigurationBuilder AddSwitch(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<ISwitchMqttEntityConfigurationBuilder, ISwitchMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<SwitchDomain, ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

        ISwitchMqttEntityConfigurationBuilder builder = new SwitchMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddSwitch(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        ISwitchMqttEntityConfigurationBuilder mqttEntityConfiguration)
    {
        configurationBuilder.AddDomain<SwitchDomain, ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
