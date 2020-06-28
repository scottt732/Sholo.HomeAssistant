using System;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers
{
    public class DelegateCommandHandler<TEntity, TEntityDefinition> : ICommandHandler<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        private Func<TEntityDefinition, string> TopicPatternSelector { get; }
        private Func<MqttCommandContext<TEntity, TEntityDefinition>, string, Task<bool>> CommandProcessor { get; }

        public string GetTopicPattern(TEntityDefinition entityDefinition)
            => TopicPatternSelector(entityDefinition);

        public Task<bool> ProcessCommand(MqttCommandContext<TEntity, TEntityDefinition> context, string payload)
            => CommandProcessor.Invoke(context, payload);

        public DelegateCommandHandler(
            Func<TEntityDefinition, string> topicPatternSelector,
            Func<MqttCommandContext<TEntity, TEntityDefinition>, string, Task<bool>> commandProcessor
        )
        {
            TopicPatternSelector = topicPatternSelector ?? throw new ArgumentNullException(nameof(topicPatternSelector));
            CommandProcessor = commandProcessor ?? throw new ArgumentNullException(nameof(commandProcessor));
        }
    }
}
