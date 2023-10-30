namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly ButtonDomain ButtonDomain = new();

    public static ButtonDomain Button(this IDomainRegistry registry) => registry.TryAddDomain(ButtonDomain);
}
