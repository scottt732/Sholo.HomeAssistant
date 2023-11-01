namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly EventDomain EventDomain = new();

    public static EventDomain Event(this IDomainRegistry registry) => registry.TryAddDomain(EventDomain);
}
