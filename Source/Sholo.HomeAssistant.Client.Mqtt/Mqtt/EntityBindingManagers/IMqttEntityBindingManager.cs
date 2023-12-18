using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.Mqtt;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

public interface IMqttEntityBindingManager : IEntityBindingManager
{
    IEnumerable<Func<IMqttRequestContext, Task<bool>>> GetTopicMessageHandlers();
}

public interface IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManager, IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
}
