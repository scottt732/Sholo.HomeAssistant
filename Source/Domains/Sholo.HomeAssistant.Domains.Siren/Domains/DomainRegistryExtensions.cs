namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly SirenDomain SirenDomain = new();

    public static SirenDomain Siren(this IDomainRegistry registry) => registry.TryAddDomain(SirenDomain);
}
