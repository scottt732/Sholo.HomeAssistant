namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly WaterHeaterDomain WaterHeaterDomain = new();

    public static WaterHeaterDomain WaterHeater(this IDomainRegistry registry) => registry.TryAddDomain(WaterHeaterDomain);
}
