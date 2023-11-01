namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly DeviceTrackerDomain DeviceTrackerDomain = new();

    public static DeviceTrackerDomain DeviceTracker(this IDomainRegistry registry) => registry.TryAddDomain(DeviceTrackerDomain);
}
