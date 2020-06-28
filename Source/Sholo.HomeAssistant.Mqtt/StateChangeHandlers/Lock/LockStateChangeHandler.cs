using System;
using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Lock
{
    public class LockStateChangeHandler : BaseStateChangeHandler<ILock, ILockEntityDefinition>
    {
        protected override string GetStateMessagePayload(ILockEntityDefinition entityDefinition, ILock entity)
            => entity.Value switch
            {
                LockState.Locked => entityDefinition.StateLocked,
                LockState.Unlocked => entityDefinition.StateUnlocked,
                LockState.Unknown => throw new NotImplementedException(), // TODO
                _ => throw new ArgumentOutOfRangeException(nameof(entity))
            };

        protected override IObservable<Unit> GetStateChangeDetector(ILock entity) => entity.Values.Select(_ => Unit.Default);
    }
}
