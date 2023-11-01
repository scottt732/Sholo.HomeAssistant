namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly FanDomain FanDomain = new();

    public static FanDomain Fan(this IDomainRegistry registry) => registry.TryAddDomain(FanDomain);
}
