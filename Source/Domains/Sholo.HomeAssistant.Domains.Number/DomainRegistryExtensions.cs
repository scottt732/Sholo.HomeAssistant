namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Number(this IDomainRegistry registry) => registry.TryAddDomain("number");
}
