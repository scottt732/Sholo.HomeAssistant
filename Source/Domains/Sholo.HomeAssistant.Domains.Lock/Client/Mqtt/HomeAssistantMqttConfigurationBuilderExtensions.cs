using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantMqttConfigurationBuilder AddLock(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        Func<ILockMqttEntityConfigurationBuilder, ILockMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

        ILockMqttEntityConfigurationBuilder builder = new LockMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddLock(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        ILockMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
