namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain Sensor(this IDomainRegistry registry) => registry.TryAddDomain("sensor");
}
