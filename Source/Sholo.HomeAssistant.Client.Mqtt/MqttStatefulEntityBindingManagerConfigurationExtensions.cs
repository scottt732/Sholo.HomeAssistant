using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

namespace Sholo.HomeAssistant.Client;

[PublicAPI]
public static class MqttStatefulEntityBindingManagerConfigurationExtensions
{
    public static IEntityBindingManager CreateBindingManager(this IMqttStatefulEntityBindingManagerConfiguration configuration, IServiceProvider serviceProvider)
    {
        var mqttEntityBindingManagerType = typeof(MqttStatefulEntityBindingManager<,,,>).MakeGenericType(
            configuration.DomainType,
            configuration.MqttEntityConfigurationType,
            configuration.EntityType,
            configuration.EntityDefinitionType
        );

        var constructor = mqttEntityBindingManagerType.GetConstructors().Single(x => x.IsPublic);
        var constructorParameters = constructor.GetParameters();
        var constructorArguments = constructorParameters.Select(x => serviceProvider.GetRequiredService(x.ParameterType)).ToArray();

        var mqttEntityBindingManager = constructor.Invoke(constructorArguments);

        return (IEntityBindingManager)mqttEntityBindingManager;
    }
}
