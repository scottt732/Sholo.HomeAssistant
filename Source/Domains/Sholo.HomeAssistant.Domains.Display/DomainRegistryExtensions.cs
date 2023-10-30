namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Display(this IDomainRegistry registry) => registry.TryAddDomain("display");
}
