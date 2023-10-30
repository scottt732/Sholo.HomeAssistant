using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface ILockEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, ILockEntityDefinition>
    where TSelf : ILockEntityDefinitionBuilder<TSelf>
{
    TSelf WithLockPayloads(string lockPayload = "LOCK", string unlockPayload = "UNLOCK");
    TSelf WithLockStates(string lockedState = "LOCKED", string unlockedState = "UNLOCKED");
}
