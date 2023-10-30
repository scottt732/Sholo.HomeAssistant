namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain InputBoolean(this IDomainRegistry registry) => registry.TryAddDomain("input_boolean");
}
