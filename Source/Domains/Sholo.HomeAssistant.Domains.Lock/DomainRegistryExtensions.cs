namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Lock(this IDomainRegistry registry) => registry.TryAddDomain("lock");
}
