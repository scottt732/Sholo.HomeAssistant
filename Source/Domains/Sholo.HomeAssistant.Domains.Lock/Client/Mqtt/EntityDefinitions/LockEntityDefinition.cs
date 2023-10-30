namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class LockEntityDefinition : BaseCoreSwitchEntityDefinition, ILockEntityDefinition
{
    public string PayloadLock { get; internal set; } = null!;
    public string PayloadUnlock { get; internal set; } = null!;
    public string StateLocked { get; internal set; } = null!;
    public string StateUnlocked { get; internal set; } = null!;
}
