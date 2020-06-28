using System;
using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers.BinarySensor
{
    public class BinarySensorStateChangeHandler : BaseStateChangeHandler<IBinarySensor, IBinarySensorEntityDefinition>
    {
        protected override string GetStateMessagePayload(IBinarySensorEntityDefinition entityDefinition, IBinarySensor entity)
            => entity.Value == BinarySensorState.On
                ? entityDefinition.PayloadOn // TODO: this is StateOn/StateOff in switch
                : entityDefinition.PayloadOff;

        protected override IObservable<Unit> GetStateChangeDetector(IBinarySensor entity) => entity.Values.Select(_ => Unit.Default);
    }
}
