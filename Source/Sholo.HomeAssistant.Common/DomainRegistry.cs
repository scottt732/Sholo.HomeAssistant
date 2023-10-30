using System;
using System.Collections.Concurrent;

namespace Sholo.HomeAssistant;

public class DomainRegistry : IDomainRegistry
{
    public static IDomainRegistry Instance => InstanceFactory.Value;

    private static readonly Lazy<IDomainRegistry> InstanceFactory = new(() => new DomainRegistry());

    private ConcurrentDictionary<string, IDomain> DomainsByName { get; } = new(StringComparer.OrdinalIgnoreCase);

    public TDomain TryAddDomain<TDomain>(TDomain domain)
        where TDomain : class, IDomain
    {
        var existingDomain = DomainsByName.GetOrAdd(domain.Name, _ => domain);

        if (existingDomain.Name != domain.Name)
        {
            throw new InvalidOperationException();
        }

        return domain;
    }

    private DomainRegistry()
    {
    }
}
