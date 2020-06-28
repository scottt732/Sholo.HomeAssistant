using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Sholo.HomeAssistant.Mqtt.Entities.Switch
{
    public class Switch : ISwitch, IDisposable
    {
        public SwitchState Value
        {
            get => _switchSubject.Value;
            set => _switchSubject.OnNext(value);
        }

        public IObservable<SwitchState> Values { get; }

        private readonly BehaviorSubject<SwitchState> _switchSubject;

        public Switch(SwitchState? initialValue = null)
        {
            _switchSubject = new BehaviorSubject<SwitchState>(initialValue ?? SwitchState.Unknown);
            Values = _switchSubject.AsObservable();
        }

        public void TurnOff()
        {
            if (Value != SwitchState.Off)
            {
                Value = SwitchState.Off;
            }
        }

        public void TurnOn()
        {
            if (Value != SwitchState.On)
            {
                Value = SwitchState.On;
            }
        }

        public void Toggle()
        {
            var state = Value;
            if (state == SwitchState.Off || state == SwitchState.Unknown)
            {
                Value = SwitchState.On;
            }
            else if (state == SwitchState.On)
            {
                Value = SwitchState.Off;
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
                _switchSubject.Dispose();
            }
        }
    }
}
