using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.State;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface IBinarySensor : IStatefulEntity
{
    BinarySensorState Value { get; }
    IObservable<BinarySensorState> Values { get; }
    void SetOff();
    void SetOn();
}
