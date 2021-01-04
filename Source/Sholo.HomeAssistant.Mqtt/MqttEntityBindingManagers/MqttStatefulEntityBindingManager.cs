using System.Collections.Generic;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers
{
    public class MqttStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : BaseMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        public MqttStatefulEntityBindingManager(IEnumerable<TMqttEntityConfiguration> entityConfigurations)
            : base(
                entityConfigurations,
                isec => new MqttStatefulEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(isec))
        {
        }
    }
}
