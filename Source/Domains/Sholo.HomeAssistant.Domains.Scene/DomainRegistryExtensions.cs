namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Scene(this IDomainRegistry registry) => registry.TryAddDomain("scene");
}
