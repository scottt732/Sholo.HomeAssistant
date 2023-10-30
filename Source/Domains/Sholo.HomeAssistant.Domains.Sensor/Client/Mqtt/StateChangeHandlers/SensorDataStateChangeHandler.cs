using System.Reactive;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

[PublicAPI]
public class SensorDataStateChangeHandler : BaseStateChangeHandler<ISensor, ISensorEntityDefinition>
{
    public override string GetStateMessagePayload(ISensorEntityDefinition entityDefinition, ISensor entity) => SerializeJson(entity);
    public override IObservable<Unit> GetStateChangeDetector(ISensor entity) => entity.Values.Select(_ => Unit.Default);
}
