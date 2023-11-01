namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly TagScannerDomain TagScannerDomain = new();

    public static TagScannerDomain TagScanner(this IDomainRegistry registry) => registry.TryAddDomain(TagScannerDomain);
}
