using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.State;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public class BinarySensorStateChangeHandler : BaseStateChangeHandler<IBinarySensor, IBinarySensorEntityDefinition>
{
    public override string GetStateMessagePayload(IBinarySensorEntityDefinition entityDefinition, IBinarySensor entity)
        => entity.Value == BinarySensorState.On
            ? entityDefinition.PayloadOn // TODO: this is StateOn/StateOff in switch
            : entityDefinition.PayloadOff;

    public override IObservable<Unit> GetStateChangeDetector(IBinarySensor entity) => entity.Values.Select(_ => Unit.Default);
}
