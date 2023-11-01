using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.Mqtt;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public class CommandContext<TEntity, TEntityDefinition> : MqttRequestContext, ICommandContext<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public TEntity Entity { get; set; }
    public TEntityDefinition EntityDefinition { get; set; }

    public CommandContext(MqttRequestContext context, TEntity entity, TEntityDefinition entityDefinition)
        : base(context)
    {
        Entity = entity;
        EntityDefinition = entityDefinition;
    }
}
