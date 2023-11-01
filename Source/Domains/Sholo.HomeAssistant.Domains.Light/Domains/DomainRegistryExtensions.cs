namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly LightDomain LightDomain = new();

    public static LightDomain Light(this IDomainRegistry registry) => registry.TryAddDomain(LightDomain);
}
