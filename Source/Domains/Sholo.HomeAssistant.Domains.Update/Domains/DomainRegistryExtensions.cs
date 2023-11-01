namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly UpdateDomain UpdateDomain = new();

    public static UpdateDomain Update(this IDomainRegistry registry) => registry.TryAddDomain(UpdateDomain);
}
