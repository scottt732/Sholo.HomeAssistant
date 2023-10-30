namespace Sholo.HomeAssistant;

public interface IDomainRegistry
{
    TDomain TryAddDomain<TDomain>(TDomain domain)
        where TDomain : class, IDomain;
}
