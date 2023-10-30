using System.Reactive.Linq;
using System.Reactive.Subjects;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public class Lock : ILock, IDisposable
{
    public LockState Value
    {
        get => _lockStateSubject.Value;
        set => _lockStateSubject.OnNext(value);
    }

    [JsonIgnore]
    public IObservable<LockState> Values { get; }

    private readonly BehaviorSubject<LockState> _lockStateSubject;

    public Lock(LockState? initialValue = null)
    {
        _lockStateSubject = new BehaviorSubject<LockState>(initialValue ?? LockState.Unknown);
        Values = _lockStateSubject.AsObservable();
    }

    public void SetLocked()
    {
        Value = LockState.Locked;
    }

    public void SetUnlocked()
    {
        Value = LockState.Unlocked;
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
            _lockStateSubject.Dispose();
        }
    }
}
