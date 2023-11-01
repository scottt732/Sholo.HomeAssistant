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
    public static IHomeAssistantMqttClientConfigurationBuilder AddLock(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<ILockMqttEntityConfigurationBuilder, ILockMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddDomain<LockDomain, ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

        ILockMqttEntityConfigurationBuilder builder = new LockMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            var entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddLock(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        ILockMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddDomain<LockDomain, ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
