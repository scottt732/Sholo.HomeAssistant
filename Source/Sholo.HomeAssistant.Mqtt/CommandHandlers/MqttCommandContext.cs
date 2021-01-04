using Sholo.Mqtt;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers
{
    public class MqttCommandContext<TEntity, TEntityDefinition> : MqttRequestContext
    {
        public TEntity Entity { get; set; }
        public TEntityDefinition EntityDefinition { get; set; }

        public MqttCommandContext(IMqttRequestContext context, TEntity entity, TEntityDefinition entityDefinition)
            : base(context)
        {
            Entity = entity;
            EntityDefinition = entityDefinition;
        }
    }
}
