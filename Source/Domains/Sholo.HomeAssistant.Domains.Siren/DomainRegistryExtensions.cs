namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Siren(this IDomainRegistry registry) => registry.TryAddDomain("siren");
}
