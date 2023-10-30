namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Update(this IDomainRegistry registry) => registry.TryAddDomain("update");
}
