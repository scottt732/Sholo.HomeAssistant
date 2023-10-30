using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddVacuum(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<IVacuumMqttEntityConfigurationBuilder, IVacuumMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

        IVacuumMqttEntityConfigurationBuilder builder = new VacuumMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddVacuum(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        IVacuumMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
