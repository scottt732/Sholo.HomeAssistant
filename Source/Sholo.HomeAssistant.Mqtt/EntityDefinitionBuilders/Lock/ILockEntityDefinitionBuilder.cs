using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Lock
{
    [PublicAPI]
    public interface ILockEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, ILockEntityDefinition>
        where TSelf : ILockEntityDefinitionBuilder<TSelf>
    {
        TSelf WithLockPayloads(string lockPayload = "LOCK", string unlockPayload = "UNLOCK");
        TSelf WithLockStates(string lockedState = "LOCKED", string unlockedState = "UNLOCKED");
    }
}
