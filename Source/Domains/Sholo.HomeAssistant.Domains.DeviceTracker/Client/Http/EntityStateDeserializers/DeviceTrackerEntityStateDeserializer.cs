using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class DeviceTrackerEntityStateDeserializer : BaseStateDeserializer<DeviceTrackerEntityState>
{
    public override string TargetDomain { get; } = "device_tracker";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
