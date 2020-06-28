using System;

namespace Sholo.HomeAssistant.Mqtt.Entities.Sensor
{
    public interface ISensor : IStatefulEntity
    {
        float Value { get; set; }
        IObservable<float> Values { get; }
    }
}
