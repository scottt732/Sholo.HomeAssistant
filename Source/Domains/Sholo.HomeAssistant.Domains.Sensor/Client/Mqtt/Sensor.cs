using System.Reactive.Linq;
using System.Reactive.Subjects;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Mqtt;

public class Sensor : ISensor, IDisposable
{
    public float Value
    {
        get => _sensorSubject.Value;
        set => _sensorSubject.OnNext(value);
    }

    [JsonIgnore]
    public IObservable<float> Values { get; }

    private readonly BehaviorSubject<float> _sensorSubject;

    public Sensor(float initialValue = default)
    {
        _sensorSubject = new BehaviorSubject<float>(initialValue);
        Values = _sensorSubject.AsObservable();
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
            _sensorSubject.Dispose();
        }
    }
}
