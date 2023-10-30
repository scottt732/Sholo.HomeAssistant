namespace Sholo.HomeAssistant.Domains;

public static class DomainRegistryExtensions
{
    private static readonly CoverDomain CoverDomain = new();

    public static CoverDomain Cover(this IDomainRegistry registry) => registry.TryAddDomain(CoverDomain);
}
