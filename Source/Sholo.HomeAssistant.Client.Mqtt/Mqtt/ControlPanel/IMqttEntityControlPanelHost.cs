using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.Mqtt.Application.Provider;

namespace Sholo.HomeAssistant.Client.Mqtt.ControlPanel;

[PublicAPI]
public interface IMqttEntityControlPanelHost : IMqttEntityControlPanel
{
    void BindAll(IMqttApplicationProvider mqttApplicationProvider, IMqttMessageBus mqttMessageBus, bool sendDiscovery);
}
