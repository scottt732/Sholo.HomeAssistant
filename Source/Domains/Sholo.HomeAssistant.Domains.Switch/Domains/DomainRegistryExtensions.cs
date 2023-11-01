namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly SwitchDomain SwitchDomain = new();

    public static SwitchDomain Switch(this IDomainRegistry registry) => registry.TryAddDomain(SwitchDomain);
}
