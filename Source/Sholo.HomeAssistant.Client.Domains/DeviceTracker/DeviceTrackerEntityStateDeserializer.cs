using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.DeviceTracker
{
    public class DeviceTrackerEntityStateDeserializer : BaseStateDeserializer<DeviceTrackerEntityState>
    {
        public override string TargetDomain { get; } = "device_tracker";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}