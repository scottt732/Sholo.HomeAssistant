using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Entities.BinarySensor
{
    [PublicAPI]
    public class BinarySensor : IBinarySensor, IDisposable
    {
        public BinarySensorState Value { get; set; }
        public IObservable<BinarySensorState> Values { get; }

        private readonly BehaviorSubject<BinarySensorState> _binarySensorSubject;

        public BinarySensor(BinarySensorState initialValue = BinarySensorState.Unknown)
        {
            _binarySensorSubject = new BehaviorSubject<BinarySensorState>(initialValue);
            Values = _binarySensorSubject.AsObservable();
        }

        private BinarySensorState State
        {
            get => _binarySensorSubject.Value;
            set => _binarySensorSubject.OnNext(value);
        }

        public void SetOff()
        {
            if (State != BinarySensorState.Off)
            {
                State = BinarySensorState.Off;
            }
        }

        public void SetOn()
        {
            if (State != BinarySensorState.On)
            {
                State = BinarySensorState.On;
            }
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
                _binarySensorSubject.Dispose();
            }
        }
    }
}
