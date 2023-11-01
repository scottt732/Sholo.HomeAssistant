using System;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant;

[PublicAPI]
public class MqttStatefulEntityBindingManagerConfiguration<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttStatefulEntityBindingManagerConfiguration
    where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    public Type DomainType => typeof(TDomain);
    public Type MqttEntityConfigurationType => typeof(TMqttEntityConfiguration);
    public Type EntityType => typeof(TEntity);
    public Type EntityDefinitionType => typeof(TEntityDefinition);
}
