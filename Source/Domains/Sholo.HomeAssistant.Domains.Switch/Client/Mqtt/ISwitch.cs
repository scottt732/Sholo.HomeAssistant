using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface ISwitch : ICoreSwitchEntity
{
    SwitchState Value { get; set; }
    IObservable<SwitchState> Values { get; }

    void TurnOff();
    void TurnOn();
    void Toggle();
}
