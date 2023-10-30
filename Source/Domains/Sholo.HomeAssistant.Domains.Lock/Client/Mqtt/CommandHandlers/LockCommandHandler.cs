using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public class LockCommandHandler : ICommandHandler<ILock, ILockEntityDefinition>
{
    public string GetTopicPattern(ILockEntityDefinition entityDefinition) => entityDefinition.CommandTopic;

    public Task<bool> ProcessCommandAsync(ICommandContext<ILock, ILockEntityDefinition> context, string payload)
    {
        if (payload.Equals(context.EntityDefinition.PayloadLock, StringComparison.Ordinal))
        {
            context.Entity.Value = LockState.Locked;
            return Task.FromResult(true);
        }
        else if (payload.Equals(context.EntityDefinition.PayloadUnlock, StringComparison.Ordinal))
        {
            context.Entity.Value = LockState.Unlocked;
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}
