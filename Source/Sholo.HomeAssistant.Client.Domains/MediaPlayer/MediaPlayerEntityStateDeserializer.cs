using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.MediaPlayer
{
    public class MediaPlayerEntityStateDeserializer : BaseStateDeserializer<MediaPlayerEntityState>
    {
        public override string TargetDomain { get; } = "media_player";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}
