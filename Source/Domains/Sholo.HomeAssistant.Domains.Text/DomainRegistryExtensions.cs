namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Text(this IDomainRegistry registry) => registry.TryAddDomain("text");
}
