using Sholo.HomeAssistant.Client.Http.EntityStates;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

namespace Sholo.HomeAssistant.Client.Http.EntityStateDeserializers;

public class DeviceTriggerEntityStateDeserializer : BaseStateDeserializer<DeviceTriggerEntityState>
{
    public override string TargetDomain { get; } = "device_automation";
    public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
}
