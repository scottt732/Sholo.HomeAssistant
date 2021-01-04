using System.Collections.Generic;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers
{
    public class MqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : BaseMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        public MqttEntityBindingManager(IEnumerable<TMqttEntityConfiguration> entityConfigurations)
            : base(
                entityConfigurations,
                isec => new MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(isec))
        {
        }
    }
}
