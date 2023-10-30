namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Group(this IDomainRegistry registry) => registry.TryAddDomain("group");
}
