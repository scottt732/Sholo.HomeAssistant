using System.Reactive;
using System.Reactive.Subjects;
using Sholo.HomeAssistant.Client.Mqtt.Entities;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface IDeviceTrigger : IEntity
{
    ISubject<Unit> TriggerSubject { get; }
    void Trigger();
}
