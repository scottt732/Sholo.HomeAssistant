namespace Sholo.HomeAssistant.Domains;

public static class DomainRegistryExtensions
{
    private static readonly DeviceTriggerDomain DeviceTriggerDomain = new();

    public static DeviceTriggerDomain DeviceTrigger(this IDomainRegistry registry) => registry.TryAddDomain(DeviceTriggerDomain);
}
