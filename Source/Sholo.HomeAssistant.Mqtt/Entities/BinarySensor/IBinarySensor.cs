using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.BinarySensor
{
    [PublicAPI]
    public interface IBinarySensor : IStatefulEntity
    {
        BinarySensorState Value { get; }
        IObservable<BinarySensorState> Values { get; }
        void SetOff();
        void SetOn();
    }
}
