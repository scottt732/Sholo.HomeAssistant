namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain TagScanner(this IDomainRegistry registry) => registry.TryAddDomain("tag_scanner");
}
