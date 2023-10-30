using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface ILock : ICoreSwitchEntity
{
    LockState Value { get; set; }
    IObservable<LockState> Values { get; }

    void SetLocked();
    void SetUnlocked();
}
