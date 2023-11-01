namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly InputBooleanDomain InputBooleanDomain = new();

    public static InputBooleanDomain InputBoolean(this IDomainRegistry registry) => registry.TryAddDomain(InputBooleanDomain);
}
