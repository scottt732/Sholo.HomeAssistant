namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly ScriptDomain ScriptDomain = new();

    public static ScriptDomain Script(this IDomainRegistry registry) => registry.TryAddDomain(ScriptDomain);
}
