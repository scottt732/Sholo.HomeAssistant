using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurationBuilders;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class HomeAssistantMqttConfigurationBuilderExtensions
{
    public static IHomeAssistantDomainsConfigurationBuilder AddAlarmControlPanel(
        this IHomeAssistantDomainsConfigurationBuilder configurationBuilder,
        Func<IAlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanelMqttEntityConfigurationBuilder> configurator)
    {
        configurationBuilder.TryRegisterStatefulEntityBindingManager<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

        IAlarmControlPanelMqttEntityConfigurationBuilder builder = new AlarmControlPanelMqttEntityConfigurationBuilder();
        builder = configurator(builder);

        configurationBuilder.ServiceCollection.AddSingleton(_ =>
        {
            IAlarmControlPanelMqttEntityConfiguration entityConfiguration = builder.Build();
            return entityConfiguration;
        });

        return configurationBuilder;
    }

    public static IHomeAssistantMqttConfigurationBuilder AddAlarmControlPanel(
        this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
        IAlarmControlPanelMqttEntityConfiguration mqttEntityConfiguration)
    {
        configurationBuilder.TryRegisterStatefulEntityBindingManager<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

        configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
        return configurationBuilder;
    }
}
