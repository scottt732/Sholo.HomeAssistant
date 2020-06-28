using System.Threading.Tasks;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers
{
    public interface ICommandHandler<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        string GetTopicPattern(TEntityDefinition entityDefinition);
        Task<bool> ProcessCommand(MqttCommandContext<TEntity, TEntityDefinition> context, string payload);
    }
}
