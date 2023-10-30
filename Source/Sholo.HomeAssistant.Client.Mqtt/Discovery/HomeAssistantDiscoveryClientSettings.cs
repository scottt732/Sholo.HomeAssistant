namespace Sholo.HomeAssistant.Client.Mqtt.Discovery;

[PublicAPI]
public class HomeAssistantDiscoveryClientSettings
{
    public string DiscoveryPrefix { get; set; } = "homeassistant";
    public QualityOfServiceLevel? QualityOfService { get; set; }
    public bool? Retain { get; set; }
}
