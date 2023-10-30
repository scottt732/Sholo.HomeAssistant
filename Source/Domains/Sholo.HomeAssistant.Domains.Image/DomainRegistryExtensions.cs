namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Image(this IDomainRegistry registry) => registry.TryAddDomain("image");
}
