namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly SceneDomain SceneDomain = new();

    public static SceneDomain Scene(this IDomainRegistry registry) => registry.TryAddDomain(SceneDomain);
}
