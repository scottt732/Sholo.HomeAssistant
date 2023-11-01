namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly TextDomain TextDomain = new();

    public static TextDomain Text(this IDomainRegistry registry) => registry.TryAddDomain(TextDomain);
}
