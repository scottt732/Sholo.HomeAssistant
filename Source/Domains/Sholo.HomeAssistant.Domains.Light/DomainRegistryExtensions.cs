namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Light(this IDomainRegistry registry) => registry.TryAddDomain("light");
}
