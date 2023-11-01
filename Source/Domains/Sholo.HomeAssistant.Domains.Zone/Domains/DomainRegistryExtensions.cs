namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly ZoneDomain ZoneDomain = new();

    public static ZoneDomain Zone(this IDomainRegistry registry) => registry.TryAddDomain(ZoneDomain);
}
