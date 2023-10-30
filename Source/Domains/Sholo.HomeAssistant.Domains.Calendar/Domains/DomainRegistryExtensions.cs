namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly CalendarDomain CalendarDomain = new();

    public static CalendarDomain Calendar(this IDomainRegistry registry) => registry.TryAddDomain(CalendarDomain);
}
