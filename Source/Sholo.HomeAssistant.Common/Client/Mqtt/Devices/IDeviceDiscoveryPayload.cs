namespace Sholo.HomeAssistant.Client.Mqtt.Devices;

[PublicAPI]
public interface IDeviceDiscoveryPayload
{
    IDevice Device { get; }
}
