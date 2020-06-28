using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.Lock
{
    [PublicAPI]
    public interface ILock : ICoreSwitchEntity
    {
        LockState Value { get; set; }
        IObservable<LockState> Values { get; }

        void SetLocked();
        void SetUnlocked();
    }
}
