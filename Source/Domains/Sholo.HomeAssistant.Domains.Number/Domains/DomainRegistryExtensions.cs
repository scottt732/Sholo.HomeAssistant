namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly NumberDomain NumberDomain = new();

    public static NumberDomain Number(this IDomainRegistry registry) => registry.TryAddDomain(NumberDomain);
}
