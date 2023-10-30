using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public class LockEntityDefinitionBuilder
    : BaseCoreSwitchEntityDefinitionBuilder<LockEntityDefinitionBuilder, ILockEntityDefinition, LockEntityDefinition>,
        ILockEntityDefinitionBuilder<LockEntityDefinitionBuilder>
{
    public LockEntityDefinitionBuilder WithLockPayloads(string lockPayload = "LOCK", string unlockPayload = "UNLOCK")
    {
        Target.PayloadLock = lockPayload;
        Target.PayloadUnlock = unlockPayload;
        return this;
    }

    public LockEntityDefinitionBuilder WithLockStates(string lockedState = "LOCKED", string unlockedState = "UNLOCKED")
    {
        Target.StateLocked = lockedState;
        Target.StateUnlocked = unlockedState;
        return this;
    }
}
