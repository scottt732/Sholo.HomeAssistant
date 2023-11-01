namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly ImageDomain ImageDomain = new();

    public static ImageDomain Image(this IDomainRegistry registry) => registry.TryAddDomain(ImageDomain);
}
