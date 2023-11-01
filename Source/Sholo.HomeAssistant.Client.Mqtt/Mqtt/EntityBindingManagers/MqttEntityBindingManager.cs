using System.Collections.Generic;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindings;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

public class MqttEntityBindingManager<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition> : BaseMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
    where TDomain : class, IDomain, new()
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public MqttEntityBindingManager(IEnumerable<TMqttEntityConfiguration> entityConfigurations)
        : base(
            new TDomain(),
            entityConfigurations,
            isec => new MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(isec),
            (mqttRequestContext, mqttEntityBinding) => new CommandContext<TEntity, TEntityDefinition>(mqttRequestContext, mqttEntityBinding.EntityConfiguration.Entity, mqttEntityBinding.EntityConfiguration.EntityDefinition))
    {
    }
}
