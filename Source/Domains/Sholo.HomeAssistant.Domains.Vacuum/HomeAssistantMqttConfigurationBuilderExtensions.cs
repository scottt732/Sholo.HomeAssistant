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
    public static IHomeAssistantMqttClientConfigurationBuilder AddVacuum(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<IVacuumMqttEntityConfigurationBuilder, IVacuumMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<VacuumDomain, IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

        IVacuumMqttEntityConfigurationBuilder builder = new VacuumMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddVacuum(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        IVacuumMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddDomain<VacuumDomain, IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
