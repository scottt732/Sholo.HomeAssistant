using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

public interface ISensor : IStatefulEntity
{
    float Value { get; set; }
    IObservable<float> Values { get; }
}
