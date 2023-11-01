namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly GroupDomain GroupDomain = new();

    public static GroupDomain Group(this IDomainRegistry registry) => registry.TryAddDomain(GroupDomain);
}
