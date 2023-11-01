namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly ClimateDomain ClimateDomain = new();

    public static ClimateDomain Climate(this IDomainRegistry registry) => registry.TryAddDomain(ClimateDomain);
}
