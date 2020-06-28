using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.MediaPlayer
{
    [PublicAPI]
    public enum MediaPlayerStateValue
    {
        Unavailable,
        Standby,
        Off,
        On,
        Paused,
        Idle,
        Playing
    }
}
