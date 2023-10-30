using System.Globalization;
using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public class SensorValuesStateChangeHandler : BaseStateChangeHandler<ISensor, ISensorEntityDefinition>
{
    public override string GetStateMessagePayload(ISensorEntityDefinition entityDefinition, ISensor entity) => entity.Value.ToString(CultureInfo.InvariantCulture);
    public override IObservable<Unit> GetStateChangeDetector(ISensor entity) => entity.Values.Select(_ => Unit.Default);
}
