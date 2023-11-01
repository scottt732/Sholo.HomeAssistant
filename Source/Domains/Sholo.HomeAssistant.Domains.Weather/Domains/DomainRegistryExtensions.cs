namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly WeatherDomain WeatherDomain = new();

    public static WeatherDomain Weather(this IDomainRegistry registry) => registry.TryAddDomain(WeatherDomain);
}
