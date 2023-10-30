namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Vacuum(this IDomainRegistry registry) => registry.TryAddDomain("vacuum");
}
