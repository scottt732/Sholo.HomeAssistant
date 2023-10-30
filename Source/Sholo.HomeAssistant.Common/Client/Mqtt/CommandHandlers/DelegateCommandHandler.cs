using System;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public class DelegateCommandHandler<TEntity, TEntityDefinition> : ICommandHandler<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    private Func<TEntityDefinition, string> TopicPatternSelector { get; }
    private Func<ICommandContext<TEntity, TEntityDefinition>, string, Task<bool>> CommandProcessor { get; }

    public string GetTopicPattern(TEntityDefinition entityDefinition)
        => TopicPatternSelector(entityDefinition);

    public Task<bool> ProcessCommandAsync(ICommandContext<TEntity, TEntityDefinition> context, string payload)
        => CommandProcessor.Invoke(context, payload);

    public DelegateCommandHandler(
        Func<TEntityDefinition, string> topicPatternSelector,
        Func<ICommandContext<TEntity, TEntityDefinition>, string, Task<bool>> commandProcessor
    )
    {
        TopicPatternSelector = topicPatternSelector ?? throw new ArgumentNullException(nameof(topicPatternSelector));
        CommandProcessor = commandProcessor ?? throw new ArgumentNullException(nameof(commandProcessor));
    }
}
