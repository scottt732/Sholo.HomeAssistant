using System;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;

namespace Sholo.HomeAssistant.Client.Mqtt.MessageBus;

public interface IMqttMessageBus
{
    void PublishMessage(IApplicationMessage message);
    IDisposable Bind();
}
