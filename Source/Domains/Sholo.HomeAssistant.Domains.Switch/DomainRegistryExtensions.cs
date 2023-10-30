namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Switch(this IDomainRegistry registry) => registry.TryAddDomain("switch");
}
