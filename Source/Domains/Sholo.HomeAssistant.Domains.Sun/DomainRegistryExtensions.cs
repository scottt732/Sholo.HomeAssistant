namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Sun(this IDomainRegistry registry) => registry.TryAddDomain("sun");
}
