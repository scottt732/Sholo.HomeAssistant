using System;
using System.Reactive;
using System.Reactive.Linq;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Sensor
{
    [PublicAPI]
    public class SensorDataStateChangeHandler : BaseStateChangeHandler<ISensor, ISensorEntityDefinition>
    {
        protected override string GetStateMessagePayload(ISensorEntityDefinition entityDefinition, ISensor entity) => SerializeJson(entity);
        protected override IObservable<Unit> GetStateChangeDetector(ISensor entity) => entity.Values.Select(_ => Unit.Default);
    }
}
