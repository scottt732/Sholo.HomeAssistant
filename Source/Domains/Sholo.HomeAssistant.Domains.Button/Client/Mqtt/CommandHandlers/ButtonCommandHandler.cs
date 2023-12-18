using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public class ButtonCommandHandler : ICommandHandler<IButton, IButtonEntityDefinition>
{
    public string GetTopicPattern(IButtonEntityDefinition entityDefinition) => entityDefinition.CommandTopic;
    public Task<bool> ProcessCommandAsync(ICommandContext<IButton, IButtonEntityDefinition> context, string payload) => context.Entity.Invoke(context, payload);
}
