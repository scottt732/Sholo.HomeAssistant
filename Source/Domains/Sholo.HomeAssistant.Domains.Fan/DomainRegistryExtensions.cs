namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Fan(this IDomainRegistry registry) => registry.TryAddDomain("fan");
}
