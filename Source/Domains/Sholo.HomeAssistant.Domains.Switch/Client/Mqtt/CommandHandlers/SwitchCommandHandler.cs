using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

[PublicAPI]
public class SwitchCommandHandler : ICommandHandler<ISwitch, ISwitchEntityDefinition>
{
    public string GetTopicPattern(ISwitchEntityDefinition entityDefinition) => entityDefinition.CommandTopic;

    public Task<bool> ProcessCommandAsync(ICommandContext<ISwitch, ISwitchEntityDefinition> context, string payload)
    {
        if (payload.Equals(context.EntityDefinition.PayloadOn, StringComparison.Ordinal))
        {
            context.Entity.Value = SwitchState.On;
            return Task.FromResult(true);
        }
        else if (payload.Equals(context.EntityDefinition.PayloadOff, StringComparison.Ordinal))
        {
            context.Entity.Value = SwitchState.Off;
            return Task.FromResult(true);
        }

        /* TODO: Does this make sense?
        else
        {
            context.Entity.Value = SwitchState.Unknown;
            return Task.FromResult(true);
        }
        */

        return Task.FromResult(false);
    }
}
