namespace Sholo.HomeAssistant.Domains;

public static class DomainRegistryExtensions
{
    private static readonly ClimateDomain ClimateDomain = new();

    public static ClimateDomain Climate(this IDomainRegistry registry) => registry.TryAddDomain(ClimateDomain);
}
