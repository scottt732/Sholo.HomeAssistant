namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly PersonDomain PersonDomain = new();

    public static PersonDomain Person(this IDomainRegistry registry) => registry.TryAddDomain(PersonDomain);
}
