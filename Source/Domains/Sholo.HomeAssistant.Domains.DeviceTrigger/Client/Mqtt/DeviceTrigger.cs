using System.Reactive;
using System.Reactive.Subjects;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public class DeviceTrigger : IDeviceTrigger, IDisposable
{
    public ISubject<Unit> TriggerSubject => _triggerSubject;

    private readonly Subject<Unit> _triggerSubject = new();

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
