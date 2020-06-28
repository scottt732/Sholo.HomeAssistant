using System;
using System.Reactive;
using System.Reactive.Subjects;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger
{
    [PublicAPI]
    public class DeviceTrigger : IDeviceTrigger, IDisposable
    {
        public ISubject<Unit> TriggerSubject => _triggerSubject;

        private readonly Subject<Unit> _triggerSubject = new Subject<Unit>();

        public void Trigger()
        {
            _triggerSubject.OnNext(Unit.Default);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _triggerSubject.Dispose();
            }
        }
    }
}
