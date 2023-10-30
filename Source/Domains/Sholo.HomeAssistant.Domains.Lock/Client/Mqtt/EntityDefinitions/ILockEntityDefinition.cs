namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public interface ILockEntityDefinition : ICoreSwitchEntityDefinition
{
    /// <summary>
    /// The payload that represents enabled/locked state.
    /// </summary>
    string PayloadLock { get; }

    /// <summary>
    /// The payload that represents disabled/unlocked state.
    /// </summary>
    string PayloadUnlock { get; }

    /// <summary>
    /// The value that represents the lock to be in locked state
    /// </summary>
    string StateLocked { get; }

    /// <summary>
    /// The value that represents the lock to be in unlocked state
    /// </summary>
    string StateUnlocked { get; }
}
