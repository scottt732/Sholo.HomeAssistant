using System;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers.Lock
{
    public class LockCommandHandler : ICommandHandler<ILock, ILockEntityDefinition>
    {
        public string GetTopicPattern(ILockEntityDefinition entityDefinition) => entityDefinition.CommandTopic;

        public Task<bool> ProcessCommand(MqttCommandContext<ILock, ILockEntityDefinition> context, string payload)
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
}
