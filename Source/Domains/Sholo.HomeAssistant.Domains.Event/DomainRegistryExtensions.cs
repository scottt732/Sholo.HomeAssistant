namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Event(this IDomainRegistry registry) => registry.TryAddDomain("event");
}
