using System;
using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Switch
{
    public class SwitchStateChangeHandler : BaseStateChangeHandler<ISwitch, ISwitchEntityDefinition>
    {
        protected override string GetStateMessagePayload(ISwitchEntityDefinition entityDefinition, ISwitch entity)
            => entity.Value switch
            {
                SwitchState.On => entityDefinition.StateOn,
                SwitchState.Off => entityDefinition.StateOff,
                SwitchState.Unknown => null, // TODO
                _ => throw new ArgumentOutOfRangeException(nameof(entity))
            };

        protected override IObservable<Unit> GetStateChangeDetector(ISwitch entity) => entity.Values.Select(_ => Unit.Default);
    }
}
