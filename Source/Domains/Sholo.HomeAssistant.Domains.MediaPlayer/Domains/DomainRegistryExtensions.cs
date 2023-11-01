namespace Sholo.HomeAssistant.Domains;

[PublicAPI]
public static class DomainRegistryExtensions
{
    private static readonly MediaPlayerDomain MediaPlayerDomain = new();

    public static MediaPlayerDomain MediaPlayer(this IDomainRegistry registry) => registry.TryAddDomain(MediaPlayerDomain);
}
