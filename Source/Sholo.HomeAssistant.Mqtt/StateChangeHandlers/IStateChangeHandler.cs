using System;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.Dispatchers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers
{
    public interface IStateChangeHandler<in TEntity, in TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        IDisposable Bind(
            IOutboundMqttMessageBusPublisher target,
            TEntity entity,
            TEntityDefinition entityDefinition,
            MqttQualityOfServiceLevel? qualityOfServiceLevel,
            bool retainMessages
        );
    }
}
