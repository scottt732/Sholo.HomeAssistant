using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.Switch
{
    [PublicAPI]
    public interface ISwitch : ICoreSwitchEntity
    {
        SwitchState Value { get; set; }
        IObservable<SwitchState> Values { get; }

        void TurnOff();
        void TurnOn();
        void Toggle();
    }
}
