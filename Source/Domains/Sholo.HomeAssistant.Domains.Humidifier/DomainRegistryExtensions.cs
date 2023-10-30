namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Humidifier(this IDomainRegistry registry) => registry.TryAddDomain("humidifier");
}
