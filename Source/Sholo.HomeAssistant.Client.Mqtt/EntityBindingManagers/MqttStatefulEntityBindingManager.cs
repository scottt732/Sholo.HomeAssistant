using System.Collections.Generic;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindings;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

public class MqttStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : BaseMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
    where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    public MqttStatefulEntityBindingManager(IDomain domain, IEnumerable<TMqttEntityConfiguration> entityConfigurations)
        : base(
            domain,
            entityConfigurations,
            isec => new MqttStatefulEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(isec),
            (mqttRequestContext, mqttEntityBinding) => new CommandContext<TEntity, TEntityDefinition>(mqttRequestContext, mqttEntityBinding.EntityConfiguration.Entity, mqttEntityBinding.EntityConfiguration.EntityDefinition)
        )
    {
    }
}
