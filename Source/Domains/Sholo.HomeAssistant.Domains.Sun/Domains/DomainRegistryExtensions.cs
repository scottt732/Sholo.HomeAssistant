namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly SunDomain SunDomain = new();

    public static SunDomain Sun(this IDomainRegistry registry) => registry.TryAddDomain(SunDomain);
}
