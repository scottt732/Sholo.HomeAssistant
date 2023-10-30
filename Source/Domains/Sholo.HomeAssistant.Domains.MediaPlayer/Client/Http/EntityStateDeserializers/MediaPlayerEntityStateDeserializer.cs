using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class MediaPlayerEntityStateDeserializer : BaseStateDeserializer<MediaPlayerEntityState>
{
    public override string TargetDomain { get; } = "media_player";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
