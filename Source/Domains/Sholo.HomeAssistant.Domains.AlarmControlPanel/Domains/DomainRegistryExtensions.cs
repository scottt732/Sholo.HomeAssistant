namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly AlarmControlPanelDomain AlarmControlPanelDomain = new();

    public static AlarmControlPanelDomain AlarmControlPanel(this IDomainRegistry registry) => registry.TryAddDomain(AlarmControlPanelDomain);
}
