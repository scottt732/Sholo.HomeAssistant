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
    public static IHomeAssistantMqttClientConfigurationBuilder AddButton(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<IButtonMqttEntityConfigurationBuilder, IButtonMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<ButtonDomain, IButtonMqttEntityConfiguration, IButton, IButtonEntityDefinition>();

        IButtonMqttEntityConfigurationBuilder builder = new ButtonMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddButton(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        IButtonMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddDomain<ButtonDomain, IButtonMqttEntityConfiguration, IButton, IButtonEntityDefinition>();

        // TODO: I don't think this makes sense. I think this would be storing 1 configuration for all buttons to share. Likewise for all other domains
        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
