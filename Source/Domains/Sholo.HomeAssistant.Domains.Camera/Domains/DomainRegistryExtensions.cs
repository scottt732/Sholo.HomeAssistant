namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly CameraDomain CameraDomain = new();

    public static CameraDomain Camera(this IDomainRegistry registry) => registry.TryAddDomain(CameraDomain);
}
