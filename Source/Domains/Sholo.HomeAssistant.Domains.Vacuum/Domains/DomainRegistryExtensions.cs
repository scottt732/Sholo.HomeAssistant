namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly VacuumDomain VacuumDomain = new();

    public static VacuumDomain Vacuum(this IDomainRegistry registry) => registry.TryAddDomain(VacuumDomain);
}
