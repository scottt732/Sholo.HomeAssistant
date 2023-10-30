namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Person(this IDomainRegistry registry) => registry.TryAddDomain("person");
}
