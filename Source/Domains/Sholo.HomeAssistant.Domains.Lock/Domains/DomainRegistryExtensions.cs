namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly LockDomain LockDomain = new();

    public static LockDomain Lock(this IDomainRegistry registry) => registry.TryAddDomain(LockDomain);
}
