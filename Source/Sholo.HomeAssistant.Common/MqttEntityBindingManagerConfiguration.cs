using System;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant;

[PublicAPI]
public class MqttEntityBindingManagerConfiguration<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManagerConfiguration
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public Type DomainType => typeof(TDomain);
    public Type MqttEntityConfigurationType => typeof(TMqttEntityConfiguration);
    public Type EntityType => typeof(TEntity);
    public Type EntityDefinitionType => typeof(TEntityDefinition);
}
