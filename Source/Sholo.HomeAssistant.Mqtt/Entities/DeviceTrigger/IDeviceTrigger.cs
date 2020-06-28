using System.Reactive;
using System.Reactive.Subjects;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger
{
    [PublicAPI]
    public interface IDeviceTrigger : IEntity
    {
        ISubject<Unit> TriggerSubject { get; }
        void Trigger();
    }
}
