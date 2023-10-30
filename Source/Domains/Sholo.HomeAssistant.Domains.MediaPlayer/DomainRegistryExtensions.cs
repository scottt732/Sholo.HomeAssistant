namespace Sholo.HomeAssistant;

public static class DomainRegistryExtensions
{
    public static IDomain MediaPlayer(this IDomainRegistry registry) => registry.TryAddDomain("media_player");
}
