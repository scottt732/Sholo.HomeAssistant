using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.Discovery.Payloads
{
    [PublicAPI]
    public interface IDeviceDiscoveryPayload
    {
        IDevice Device { get; }
    }
}
