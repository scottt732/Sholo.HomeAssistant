namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain WaterHeater(this IDomainRegistry registry) => registry.TryAddDomain("water_heater");
}
