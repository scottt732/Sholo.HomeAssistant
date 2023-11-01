namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly LawnMowerDomain LawnMowerDomain = new();

    public static LawnMowerDomain LawnMower(this IDomainRegistry registry) => registry.TryAddDomain(LawnMowerDomain);
}
