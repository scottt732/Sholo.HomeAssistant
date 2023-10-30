namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly BinarySensorDomain BinarySensorDomain = new();

    public static BinarySensorDomain BinarySensor(this IDomainRegistry registry) => registry.TryAddDomain(BinarySensorDomain);
}
