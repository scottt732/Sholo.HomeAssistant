namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Script(this IDomainRegistry registry) => registry.TryAddDomain("script");
}
