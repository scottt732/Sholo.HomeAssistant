using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public class LockStateChangeHandler : BaseStateChangeHandler<ILock, ILockEntityDefinition>
{
    public override string GetStateMessagePayload(ILockEntityDefinition entityDefinition, ILock entity)
        => entity.Value switch
        {
            LockState.Locked => entityDefinition.StateLocked,
            LockState.Unlocked => entityDefinition.StateUnlocked,
            LockState.Unknown => throw new NotImplementedException(), // TODO
            _ => throw new ArgumentOutOfRangeException(nameof(entity))
        };

    public override IObservable<Unit> GetStateChangeDetector(ILock entity) => entity.Values.Select(_ => Unit.Default);
}
