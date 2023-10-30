using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Sholo.HomeAssistant.Utilities.DependencyInjection;

[PublicAPI]
public abstract class BaseServiceCollectionExtender : IServiceCollection
{
    public int Count => Target.Count;
    public bool IsReadOnly => Target.IsReadOnly;

    public ServiceDescriptor this[int index]
    {
        get => Target[index];
        set => Target[index] = value;
    }

    protected IServiceCollection Target { get; }

    protected BaseServiceCollectionExtender(IServiceCollection target)
    {
        Target = target;
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator() => Target.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Target.GetEnumerator();
    public void Add(ServiceDescriptor item) => Target.Add(item);
    public void Clear() => Target.Clear();
    public bool Contains(ServiceDescriptor item) => Target.Contains(item);
    public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => Target.CopyTo(array, arrayIndex);
    public bool Remove(ServiceDescriptor item) => Target.Remove(item);
    public int IndexOf(ServiceDescriptor item) => Target.IndexOf(item);
    public void Insert(int index, ServiceDescriptor item) => Target.Insert(index, item);
    public void RemoveAt(int index) => Target.RemoveAt(index);
}
