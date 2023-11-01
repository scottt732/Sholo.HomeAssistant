namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly HumidifierDomain HumidifierDomain = new();

    public static HumidifierDomain Humidifier(this IDomainRegistry registry) => registry.TryAddDomain(HumidifierDomain);
}
