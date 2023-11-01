namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly SensorDomain SensorDomain = new();

    public static SensorDomain Sensor(this IDomainRegistry registry) => registry.TryAddDomain(SensorDomain);
}
