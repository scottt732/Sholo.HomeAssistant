using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Camera
{
    public class CameraEntityStateDeserializer : BaseStateDeserializer<CameraEntityState>
    {
        public override string TargetDomain { get; } = "camera";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}