using System;
using System.Globalization;
using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;

namespace Sholo.HomeAssistant.Mqtt.StateChangeHandlers.Sensor
{
    public class SensorValuesStateChangeHandler : BaseStateChangeHandler<ISensor, ISensorEntityDefinition>
    {
        protected override string GetStateMessagePayload(ISensorEntityDefinition entityDefinition, ISensor entity) => entity.Value.ToString(CultureInfo.InvariantCulture);
        protected override IObservable<Unit> GetStateChangeDetector(ISensor entity) => entity.Values.Select(_ => Unit.Default);
    }
}
