namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain LawnMower(this IDomainRegistry registry) => registry.TryAddDomain("lawn_mower");
}
