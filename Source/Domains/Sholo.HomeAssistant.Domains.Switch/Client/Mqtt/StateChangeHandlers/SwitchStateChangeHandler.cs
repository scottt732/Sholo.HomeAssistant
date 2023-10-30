using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public class SwitchStateChangeHandler : BaseStateChangeHandler<ISwitch, ISwitchEntityDefinition>
{
    public override string GetStateMessagePayload(ISwitchEntityDefinition entityDefinition, ISwitch entity)
        => entity.Value switch
        {
            SwitchState.On => entityDefinition.StateOn,
            SwitchState.Off => entityDefinition.StateOff,
            SwitchState.Unknown => "Unknown", // TODO
            _ => throw new ArgumentOutOfRangeException(nameof(entity))
        };

    public override IObservable<Unit> GetStateChangeDetector(ISwitch entity) => entity.Values.Select(_ => Unit.Default);
}
