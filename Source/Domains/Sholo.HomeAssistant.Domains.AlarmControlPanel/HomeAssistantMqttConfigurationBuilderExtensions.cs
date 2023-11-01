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
    public static IHomeAssistantMqttClientConfigurationBuilder AddAlarmControlPanel(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        Func<IAlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanelMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.AddStatefulDomain<AlarmControlPanelDomain, IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

        IAlarmControlPanelMqttEntityConfigurationBuilder builder = new AlarmControlPanelMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            IAlarmControlPanelMqttEntityConfiguration entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttClientConfigurationBuilder AddAlarmControlPanel(
        this IHomeAssistantMqttClientConfigurationBuilder configurationBuilder,
        IAlarmControlPanelMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.AddStatefulDomain<AlarmControlPanelDomain, IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
