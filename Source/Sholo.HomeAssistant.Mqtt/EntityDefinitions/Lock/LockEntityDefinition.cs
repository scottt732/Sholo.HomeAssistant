namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock
{
    public class LockEntityDefinition : BaseCoreSwitchEntityDefinition, ILockEntityDefinition
    {
        public string PayloadLock { get; internal set; }
        public string PayloadUnlock { get; internal set; }
        public string StateLocked { get; internal set; }
        public string StateUnlocked { get; internal set; }
    }
}