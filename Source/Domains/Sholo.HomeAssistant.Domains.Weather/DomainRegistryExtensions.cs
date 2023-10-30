namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Weather(this IDomainRegistry registry) => registry.TryAddDomain("weather");
}
