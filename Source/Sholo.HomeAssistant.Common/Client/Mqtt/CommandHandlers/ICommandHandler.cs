using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public interface ICommandHandler<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    string GetTopicPattern(TEntityDefinition entityDefinition);
    Task<bool> ProcessCommandAsync(ICommandContext<TEntity, TEntityDefinition> context, string payload);
}
