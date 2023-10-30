using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class CameraEntityStateDeserializer : BaseStateDeserializer<CameraEntityState>
{
    public override string TargetDomain { get; } = "camera";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
